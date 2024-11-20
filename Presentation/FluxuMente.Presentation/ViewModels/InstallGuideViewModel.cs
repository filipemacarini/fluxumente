using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxuMente.Application.Abstractions;
using FluxuMente.Presentation.Navigation;
using FluxuMente.Presentation.Views;
using System.Diagnostics;

namespace FluxuMente.Presentation.ViewModels
{
    public partial class InstallGuideViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IOllamaChatService _ollamaChatService;
        private readonly IServiceProvider _serviceProvider;

        public InstallGuideViewModel(INavigationService navigationService, IOllamaChatService ollamaChatService, IServiceProvider serviceProvider)
        {
            _navigationService = navigationService;
            _ollamaChatService = ollamaChatService;
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        public async Task TestState() =>
            await NextPage(await TestConnection());
        private async Task<bool> TestConnection() =>
            await _ollamaChatService.VerifyConnectionAsync();

        private async Task NextPage(bool isConnected = true)
        {
            if (isConnected) await _navigationService.NavigateToAsync(_serviceProvider.GetRequiredService<CustomizationView>());
        }

        [RelayCommand]
        public async Task OpenUrl(string url)
        {
            await Browser.Default.OpenAsync(url);
        }

        [RelayCommand]
        public async Task GoTerminal(string command)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = command,
            });
        }
    }
}
