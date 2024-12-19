using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxuMente.Application.Abstractions;
using FluxuMente.Application.DTOs;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FluxuMente.Presentation.ViewModels
{
    public partial class CustomizationMessagesManagerViewModel : ObservableObject
    {
        private List<CustomizationMessageDTO> _baseMessages;
        private ICustomizationMessageService _customizationMessageService;

        [ObservableProperty]
        public ObservableCollection<MessageExtension> _messages;
        [ObservableProperty]
        public MessageExtension _selectedMessage;
        [ObservableProperty]
        public CustomizationMessageDTO _displayMessage;

        public CustomizationMessagesManagerViewModel(ICustomizationMessageService customizationMessageService)
        {
            _customizationMessageService = customizationMessageService;

            InitializeAsync();
        }

        public async void InitializeAsync()
        {
            await LoadMessages();
            UpdateMessageList();
            DisplayMessage = new CustomizationMessageDTO() { Id = 0, Title = "", Content = "" };
        }

        public async Task LoadMessages() =>
            _baseMessages = await _customizationMessageService.GetAllMessagesAsync();

        public void UpdateMessageList() =>
            Messages = MessageExtension.ConvertBaseListToExtensionList(_baseMessages);

        [RelayCommand]
        public void SelectedMessageChanged()
        {
            foreach (var message in Messages)
                message.BackgroundColor = Color.FromArgb("#141414");
            SelectedMessage.BackgroundColor = Color.FromArgb("#212121");

            DisplayMessage = SelectedMessage.GetBaseMessage();
        }

        [RelayCommand]
        public async void AddAsync()
        {
            if (String.IsNullOrWhiteSpace(DisplayMessage.Title) || String.IsNullOrWhiteSpace(DisplayMessage.Content)) return;
            await _customizationMessageService.AddMessageAsync(DisplayMessage);
            InitializeAsync();
        }

        [RelayCommand]
        public async void UpdateAsync()
        {
            await _customizationMessageService.UpdateMessageAsync(DisplayMessage);
            InitializeAsync();
        }

        [RelayCommand]
        public async void DeleteAsync()
        {
            await _customizationMessageService.RemoveMessageAsync(SelectedMessage.Id);
            InitializeAsync();
        }
    }

    public partial class MessageExtension : ObservableObject
    {
        [ObservableProperty]
        public int _id;
        [ObservableProperty]
        public string _title;
        [ObservableProperty]
        public string _content;
        [ObservableProperty]
        public Color _backgroundColor;
        public static ObservableCollection<MessageExtension> ConvertBaseListToExtensionList(List<CustomizationMessageDTO> messages)
        {
            var returnList = new ObservableCollection<MessageExtension>(
                messages.Select(message => new MessageExtension
                {
                    Id = message.Id,
                    Title = message.Title,
                    Content = message.Content,
                    BackgroundColor = Color.FromArgb("#141414")
                })
            );
            return returnList;
        }

        public CustomizationMessageDTO GetBaseMessage()
        {
            var returnMessage = new CustomizationMessageDTO
            {
                Id= this.Id,
                Title = this.Title,
                Content = this.Content,
            };
            return returnMessage;
        }
    }
}
