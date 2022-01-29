using Microsoft.AspNetCore.Components.WebView.Maui;
using BombasKitchen.Services;
using BombasKitchen.Data.Middleware;

namespace BombasKitchen;

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
		builder.Services.AddScoped<DataService>();
		builder.Services.AddScoped<ProductsProcessor>();
		builder.Services.AddAntDesign();

		return builder.Build();
	}
}
