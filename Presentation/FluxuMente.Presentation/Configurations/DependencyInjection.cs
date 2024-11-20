using FluxuMente.Application.Abstractions;
using FluxuMente.Application.Implementations;
using FluxuMente.Presentation.Navigation;
using FluxuMente.Presentation.Views;

namespace FluxuMente.Presentation.Configuration
{
    public class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Views
            services.AddSingleton<InstallGuideView>();
            services.AddSingleton<CustomizationView>();
            services.AddSingleton<CustomizationMessagesManagerView>();
            services.AddSingleton<ChatView>();

            // Services
            services.AddSingleton<IOllamaChatService, OllamaChatService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ICustomizationMessageService, CustomizationMessageService>();

            // HttpClients
            services.AddHttpClient<IOllamaChatService, OllamaChatService>(client =>
            {
                client.BaseAddress = new Uri("http://127.0.0.1:11434");
            });
        }
    }
}
