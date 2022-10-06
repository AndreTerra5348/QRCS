using QRCS.ViewModels;

namespace QRCS.Pages;

public partial class HistoryPage : ContentPage
{
	public HistoryPage(HistoryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}