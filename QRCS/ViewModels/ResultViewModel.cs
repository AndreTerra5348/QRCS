using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QRCS.Core.Models;
using QRCS.Core.Services;

namespace QRCS.ViewModels;

[QueryProperty(nameof(Scan), nameof(Scan))]
public sealed partial class ResultViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(
        nameof(ShareResultCommand),
        nameof(CopyResultCommand),
        nameof(OpenResultCommand),
        nameof(DeleteScanCommand))]
    private Scan _scan;

    private readonly IScanHistoryService _scanHistoryService;

    public ResultViewModel(IScanHistoryService scanHistoryService)
    {
        _scanHistoryService = scanHistoryService;
    }

    [RelayCommand(CanExecute = nameof(CanShareCommandExecute))]
    private async Task ShareResult()
    {
        await Share.RequestAsync(Scan.Result);
    }

    private bool CanShareCommandExecute()
    {
        return !String.IsNullOrEmpty(Scan?.Result);
    }

    [RelayCommand(CanExecute = nameof(CanCopyCommandExecute))]
    private async Task CopyResult()
    {
        await Clipboard.SetTextAsync(Scan.Result);
        var snackbar = Snackbar.Make("Content copied to clipboard!");
        await snackbar.Show();
    }

    private bool CanCopyCommandExecute()
    {
        return !String.IsNullOrEmpty(Scan?.Result);
    }

    [RelayCommand(CanExecute = nameof(CanOpenCommandExecute))]
    private async Task OpenResult()
    {
        await Browser.OpenAsync(Scan.Result);
    }

    private bool CanOpenCommandExecute()
    {
        return !String.IsNullOrEmpty(Scan?.Result);
    }

    [RelayCommand(CanExecute = nameof(CanDeleteCommandExecute))]
    private async Task DeleteScan()
    {
        if(await Shell.Current.DisplayAlert("Delete", "Are you sure?", "Yes", "Cancel"))
        {
            await _scanHistoryService.RemoveAsync(Scan);
            await Shell.Current.GoToAsync("..");
        }
    }

    private bool CanDeleteCommandExecute()
    {
        return Scan != null;
    }
}


