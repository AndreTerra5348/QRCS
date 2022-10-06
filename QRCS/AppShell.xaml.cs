using QRCS.Pages;
using QRCS.ViewModels;

namespace QRCS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ResultPage), typeof(ResultPage));
		Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
    }
}
