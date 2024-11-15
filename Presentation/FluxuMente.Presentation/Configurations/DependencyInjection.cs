using FluxuMente.Application.Abstractions;
using FluxuMente.Application.Implementations;
using FluxuMente.Presentation.Views;

namespace FluxuMente.Presentation.Configuration
{
    public class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Views
            services.AddSingleton<InstallGuideView>();

            // Services
            services.AddSingleton<IOllamaChatService, OllamaChatService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // HttpClients
            services.AddHttpClient<IOllamaChatService, OllamaChatService>(client =>
            {
                client.BaseAddress = new Uri("http://127.0.0.1:11434");
            });
        }
    }
}
