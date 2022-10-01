using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace QRCS.ViewModels;

[QueryProperty(nameof(Result), nameof(Result))]
public partial class ResultViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ShareResultCommand), nameof(CopyResultCommand), nameof(OpenResultCommand))]
    private string _result;

    [RelayCommand(CanExecute = nameof(CanShareCommandExecute))]
    private async void ShareResult()
    {
        await Share.RequestAsync(Result);
    }

    private bool CanShareCommandExecute()
    {
        return !String.IsNullOrEmpty(Result);
    }

    [RelayCommand(CanExecute = nameof(CanCopyResultCommandExecute))]
    private async void CopyResult()
    {
        await Clipboard.SetTextAsync(Result);
        var snackbar = Snackbar.Make("Content copied to clipboard!");
        await snackbar.Show();
    }

    private bool CanCopyResultCommandExecute()
    {
        return !String.IsNullOrEmpty(Result);
    }

    [RelayCommand(CanExecute = nameof(CanOpenResultCommandExecute))]
    private async void OpenResult()
    {
        await Browser.OpenAsync(Result);
    }

    private bool CanOpenResultCommandExecute()
    {
        return !String.IsNullOrEmpty(Result);
    }
}


