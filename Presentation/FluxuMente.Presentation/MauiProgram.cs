using FluxuMente.Presentation.Configuration;
using FluxuMente.Presentation.Configurations;
using Microsoft.Extensions.Logging;

namespace FluxuMente.Presentation
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>();

            // Configurations
            DependencyInjection.ConfigureServices(builder.Services);
            HandlerRegistry.RegisterHandlers();
            FontRegistry.ConfigureFonts(builder);

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
