using CommunityToolkit.Maui;
using QRCS.Core.FileContexties;
using QRCS.Core.Models;
using QRCS.Core.Repositories;
using QRCS.Core.Services;
using QRCS.Data.Contexties;
using QRCS.Data.Repositories;
using QRCS.Pages;
using QRCS.Service.Services;
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
			.AddTransient<ResultViewModel>()
			.AddTransient<HistoryPage>()
			.AddTransient<HistoryViewModel>();

		builder.Services
			.AddTransient<IScanHistoryService, ScanHistoryService>()
			.AddTransient<IScanRepository, ScanRepository>();

		builder.Services
			.AddSingleton<IFileContext<Scan>, FileContext>()
			.AddSingleton<IFileConfig>(s => new FileConfig(FileSystem.AppDataDirectory));

        return builder.Build();
	}
}
