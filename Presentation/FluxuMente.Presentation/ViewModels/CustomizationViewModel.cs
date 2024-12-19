using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxuMente.Application.Abstractions;
using FluxuMente.Application.DTOs;
using FluxuMente.Presentation.Navigation;
using FluxuMente.Presentation.Views;
using Microsoft.UI.Xaml;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace FluxuMente.Presentation.ViewModels
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
        [ObservableProperty]
        public int _customizationMessageIndex;

        public CustomizationViewModel(INavigationService navigationService, ICustomizationMessageService customizationMessageService, IServiceProvider serviceProvider)
        {
            _customizationMessageService = customizationMessageService;
            _navigationService = navigationService;
            _serviceProvider = serviceProvider;

            InitializeAsync();
        }

        public async void InitializeAsync()
        {
            await SetTasksAndTitles();
            CustomizationMessageTitle = CustomizationMessageTitles.FirstOrDefault() ?? "None";
            CustomizationMessageMessage = _customizationMessages[CustomizationMessageIndex].Content ?? "";
        }

        public async Task SetTasksAndTitles()
        {
            await SetAllMessagesAsync();
            SetAllMessageTitlesAsync();
        }

        public async Task SetAllMessagesAsync() =>
            _customizationMessages = await _customizationMessageService.GetAllMessagesAsync();

        public void SetAllMessageTitlesAsync() =>
            CustomizationMessageTitles = _customizationMessages.Select(msg => msg.Title).ToList();

        [RelayCommand]
        public async Task UpdateMessage()
        {
            await SetTasksAndTitles();
            CustomizationMessageMessage = _customizationMessages[CustomizationMessageIndex].Content ?? "";
        }

        [RelayCommand]
        public void NavigateToNextPage(string page)
        {
            Type pageType = Type.GetType($"FluxuMente.Presentation.Views.{page}");

            if (page == "ChatView")
            {
                ChatView chatViewInstance = new ChatView(_serviceProvider.GetService<IOllamaChatService>(), CustomizationMessageMessage);
                _navigationService.NavigateToAsync(chatViewInstance);
            }
            else
            {
                Page pageInstance = (Page)_serviceProvider.GetRequiredService(pageType);
                _navigationService.NavigateToAsync(pageInstance);
            }
        }
    }
}
