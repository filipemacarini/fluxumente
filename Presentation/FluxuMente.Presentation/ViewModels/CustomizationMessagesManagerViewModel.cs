using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxuMente.Application.DTOs;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FluxuMente.Presentation.ViewModels
{
    public partial class CustomizationMessagesManagerViewModel : ObservableObject
    {
        private List<CustomizationMessageDTO> _baseMessages;

        [ObservableProperty]
        public ObservableCollection<MessageExtension> _messages;
        [ObservableProperty]
        public MessageExtension _selectedMessage;
        [ObservableProperty]
        public CustomizationMessageDTO _displayMessage;

        public CustomizationMessagesManagerViewModel()
        {
            _baseMessages = new()
            {
                new() { Id = 0, Title = "Teste", Content = "Conteúdo" },
                new() { Id = 1, Title = "Teste", Content = "Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo" },
                new() { Id = 2, Title = "Teste", Content = "Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo, Conteúdo" },
            };

            Messages = MessageExtension.ConvertBaseListToExtensionList(_baseMessages);
        }

        [RelayCommand]
        public void SelectedMessageChanged()
        {
            foreach (var message in Messages)
                message.BackgroundColor = Color.FromArgb("#141414");
            SelectedMessage.BackgroundColor = Color.FromArgb("#212121");

            DisplayMessage = SelectedMessage.GetBaseMessage();
        }

        public async Task AddAsync()
        {

        }

        public async Task UpdateAsync()
        {

        }

        public async Task DeleteAsync()
        {

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
                Title = this.Title,
                Content = this.Content,
            };
            return returnMessage;
        }
    }
}
