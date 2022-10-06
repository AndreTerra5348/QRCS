using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QRCS.Core.Models;
using QRCS.Core.Services;
using QRCS.Pages;
using System.Collections.ObjectModel;
using ZXing.Net.Maui;

namespace QRCS.ViewModels;

public sealed partial class ScanViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isTorchOn;
    [ObservableProperty]
    private CameraLocation _cameraLocation;
    [ObservableProperty]
    private bool _isDetecting = true;

    private readonly IScanHistoryService _scanHistoryService;

    public ScanViewModel(IScanHistoryService scanHistoryService)
    {
        _scanHistoryService = scanHistoryService;
    }

    [RelayCommand]
    async Task BarcodesDetected(Scan scan)
    {
        IsDetecting = false;
        await _scanHistoryService.AddAsync(scan);
        var parameters = new Dictionary<string, object>()
        {
            ["Scan"] = scan
        };

        App.Current.MainPage.Dispatcher.Dispatch(async () => await Shell.Current.GoToAsync(nameof(ResultPage), parameters));

    }

    [RelayCommand]
    void ToggleTorch()
    {
        IsTorchOn = !IsTorchOn;
    }

    [RelayCommand]
    void SwitchCamera()
    {
        CameraLocation = CameraLocation switch
        {
            CameraLocation.Rear => CameraLocation.Front,
            CameraLocation.Front => CameraLocation.Rear,
            _ => CameraLocation.Rear
        };
    }

    [RelayCommand]
    async Task NavigateToHistoryPage()
    {
        await Shell.Current.GoToAsync(nameof(HistoryPage));
    }

    [RelayCommand]
    void NavigatedTo()
    {
        IsDetecting = true;
    }
}


