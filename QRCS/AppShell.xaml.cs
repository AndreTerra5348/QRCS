using QRCS.Pages;

namespace QRCS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ScanPage), typeof(ScanPage));
		Routing.RegisterRoute(nameof(ResultPage), typeof(ResultPage));

    }
}
