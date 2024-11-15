using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxuMente.Application.Abstractions;
using FluxuMente.Presentation.Views;
using System.Diagnostics;

namespace FluxuMente.Application.ViewModels
{
    public partial class InstallGuideViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IOllamaChatService _ollamaChatService;

        public InstallGuideViewModel(INavigationService navigationService, IOllamaChatService ollamaChatService)
        {
            _navigationService = navigationService;
            _ollamaChatService = ollamaChatService;
        }

        [RelayCommand]
        public async Task TestState() =>
            await NextPage(await TestConnection());

        private async Task<bool> TestConnection() =>
            await _ollamaChatService.VerifyConnectionAsync();

        private async Task NextPage(bool isConnected = true)
        {
            if (isConnected) await _navigationService.NavigateToAsync(new CustomizationView(_navigationService));
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
