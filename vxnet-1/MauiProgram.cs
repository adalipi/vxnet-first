using vxnet_1.Services;
using vxnet_1.Views;
namespace vxnet_1;

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

		builder.Services.AddSingleton<ShopService>();
        builder.Services.AddSingleton<ShopListViewModel>();
		builder.Services.AddTransient<ShopDetailsViewModel>();

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();

        return builder.Build();
	}
}
