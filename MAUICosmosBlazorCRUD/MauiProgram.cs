using Microsoft.AspNetCore.Components.WebView.Maui;
using MAUICosmosBlazorCRUD.Data;
using MAUICosmosBlazorCRUD.Services;

namespace MAUICosmosBlazorCRUD;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.RegisterBlazorMauiWebView()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddBlazorWebView();
		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<DBCosmosService>();

		return builder.Build();
	}
}
