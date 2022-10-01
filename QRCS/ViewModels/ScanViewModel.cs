using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QRCS.Pages;
using ZXing.Net.Maui;

namespace QRCS.ViewModels;

public partial class ScanViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isTorchOn;
    [ObservableProperty]
    private CameraLocation _cameraLocation;
    [ObservableProperty]
    private bool _isDetecting = true;

    [RelayCommand]
    void BarcodesDetected(string text)
    {
        IsDetecting = false;
        var parameters = new Dictionary<string, object>()
        { 
            { "Result", text } 
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
    void NavigatedTo()
    {
        IsDetecting = true;
    }
}


