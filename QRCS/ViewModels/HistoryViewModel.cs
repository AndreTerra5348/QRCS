using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QRCS.Core.Models;
using QRCS.Core.Services;
using QRCS.Pages;
using System.Collections.ObjectModel;

namespace QRCS.ViewModels;

public partial class HistoryViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Scan> _history;

    private readonly IScanHistoryService _scanHistoryService;
    public HistoryViewModel(IScanHistoryService scanHistoryService)
    {
        _scanHistoryService = scanHistoryService;
    }

    [RelayCommand]
    async Task Tap(Scan scan)
    {
        var parameters = new Dictionary<string, object>()
        {
            ["Scan"] = scan
        };
        await Shell.Current.GoToAsync(nameof(ResultPage), parameters);
    }

    [RelayCommand]
    void NavigatedTo()
    {
        var history = _scanHistoryService.GetAll();
        History = new ObservableCollection<Scan>(history);
    }

}


