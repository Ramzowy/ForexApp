using Microsoft.Extensions.Logging;
using ForexApp.Services;
using ForexApp.ViewModel;
using ForexApp.Views;

namespace ForexApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<ExchangeRateService>();
        builder.Services.AddTransient<CalculatorViewModel>();
        builder.Services.AddTransient<CalculatorPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
