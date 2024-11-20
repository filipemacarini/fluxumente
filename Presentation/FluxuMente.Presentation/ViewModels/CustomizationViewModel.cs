using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxuMente.Application.Abstractions;
using FluxuMente.Application.DTOs;
using FluxuMente.Presentation.Navigation;
using FluxuMente.Presentation.Views;
using Microsoft.UI.Xaml;
using System.Diagnostics;
using System.Windows.Input;

namespace FluxuMente.Application.ViewModels
{
    public partial class CustomizationViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ICustomizationMessageService _customizationMessageService;
        private readonly IServiceProvider _serviceProvider;

        private List<CustomizationMessageDTO> _customizationMessages;

        [ObservableProperty]
        public List<string> _customizationMessageTitles;
        [ObservableProperty]
        public string _customizationMessageTitle;
        [ObservableProperty]
        public string _customizationMessageMessage;

        public CustomizationViewModel(INavigationService navigationService, ICustomizationMessageService customizationMessageService, IServiceProvider serviceProvider)
        {
            _customizationMessageService = customizationMessageService;
            _navigationService = navigationService;
            _serviceProvider = serviceProvider;

            Task.Run(InitializeAsync);
        }

        public async Task InitializeAsync()
        {
            _customizationMessages = await _customizationMessageService.GetAllMessagesAsync();

            CustomizationMessageTitles = _customizationMessages.Select(msg => msg.Title).ToList();

            CustomizationMessageTitle = CustomizationMessageTitles.FirstOrDefault() ?? "None";
        }

        [RelayCommand]
        private void UpdateMessage()
        {
            CustomizationMessageMessage = _customizationMessages.Find(msg => msg.Title.Equals(CustomizationMessageTitle))?.Message ?? "";
        }

        [RelayCommand]
        public void NavigateToNextPage(string page)
        {
            Type pageType = Type.GetType($"FluxuMente.Presentation.Views.{page}");
            _navigationService.NavigateToAsync((Page)_serviceProvider.GetRequiredService(pageType));
        }
    }
}
