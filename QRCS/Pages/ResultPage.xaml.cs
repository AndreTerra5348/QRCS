using QRCS.ViewModels;

namespace QRCS.Pages;

public partial class ResultPage : ContentPage
{
	public ResultPage(ResultViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}