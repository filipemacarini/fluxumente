using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxuMente.Application.Abstractions;
using FluxuMente.Application.DTOs;
using FluxuMente.Presentation.Navigation;
using FluxuMente.Presentation.Views;
using System.Diagnostics;

namespace FluxuMente.Application.ViewModels
{
    public partial class CustomizationViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ICustomizationMessageService _customizationMessageService;

        private List<CustomizationMessageDTO> _customizationMessages;

        [ObservableProperty]
        public List<string> _customizationMessageTitles;        
        [ObservableProperty]
        public string _customizationMessage;
        [ObservableProperty]
        public string _customization;

        public CustomizationViewModel(INavigationService navigationService, ICustomizationMessageService customizationMessageService)
        {
            _customizationMessageService = customizationMessageService;
            _navigationService = navigationService;

            Task.Run(InitializeAsync);
        }

        public async Task InitializeAsync()
        {
            _customizationMessages = await _customizationMessageService.GetAllMessagesAsync();
            CustomizationMessageTitles = _customizationMessages.Select(msg => msg.Title).ToList();

            CustomizationMessage = CustomizationMessageTitles.FirstOrDefault() ?? "None";
        }

        [RelayCommand]
        private async Task NextPage() =>
            await _navigationService.NavigateToAsync(new ChatView());
    }
}
