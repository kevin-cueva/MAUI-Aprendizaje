using Microsoft.Extensions.Logging;

namespace Dispatcher;

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
			// Registramos Dispatcher como un servicio Singleton
        builder.Services.AddSingleton<IDispatcherHelper>(sp =>
        {
            var dispatcher = Application.Current!.Dispatcher; 
            return new DispatcherHelper(dispatcher);
        });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
