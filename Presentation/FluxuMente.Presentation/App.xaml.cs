using FluxuMente.Presentation.Views;

namespace FluxuMente.Presentation
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = new NavigationPage(serviceProvider.GetRequiredService<InstallGuideView>());

        }
    }
}
