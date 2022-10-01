using QRCS.ViewModels;

namespace QRCS.Pages;

public partial class ScanPage : ContentPage
{
	public ScanViewModel ViewModel { get; set; }
	public ScanPage(ScanViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}