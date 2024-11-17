using FluxuMente.Presentation.Navigation;

namespace FluxuMente.Application.Implementations
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAsync(Page page)
        {
            if (Microsoft.Maui.Controls.Application.Current?.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.PushAsync(page);
            }
        }

        public async Task GoBackAsync()
        {
            if (Microsoft.Maui.Controls.Application.Current?.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.PopAsync();
            }
        }
    }
}
