using CommunityToolkit.Maui;
using QRCS.Pages;
using QRCS.ViewModels;
using ZXing.Net.Maui;

namespace QRCS;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseBarcodeReader()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services
			.AddSingleton<AppShell>()
			.AddSingleton<ScanPage>()
			.AddSingleton<ScanViewModel>()
			.AddTransient<ResultPage>()
			.AddTransient<ResultViewModel>();


        return builder.Build();
	}
}
