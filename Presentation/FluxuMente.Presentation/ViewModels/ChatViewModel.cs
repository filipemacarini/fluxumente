using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxuMente.Application.Abstractions;
using FluxuMente.Application.DTOs;
using FluxuMente.Application.Mappers;
using System.Collections.ObjectModel;

namespace FluxuMente.Presentation.ViewModels
{
    public partial class ChatViewModel : ObservableObject
    {
        private readonly IOllamaChatService _ollamaChatService;
        private readonly string _customization;
        private readonly Page _page;

        [ObservableProperty]
        public ObservableCollection<ChatResponseMessageDTO> _messages;
        [ObservableProperty]
        public string _requestMessage;
        [ObservableProperty]
        public string _model;
        [ObservableProperty]
        public ObservableCollection<string> _models;

        public ChatViewModel(IOllamaChatService ollamaChatService, string customization, Page page)
        {
            _ollamaChatService = ollamaChatService;
            _customization = customization;
            _page = page;

            Messages = new();

            GetModelsAsync();
        }

        public async Task GetModelsAsync()
        {
            Models = new(await _ollamaChatService.GetModelNamesAsync());
            Model = Models[0];
        }

        public void FocusEntryMessage() =>
            _page.FindByName<Entry>("EntryMessage").Focus();

        [RelayCommand]
        public async Task Send()
        {
            if (Model == null || String.IsNullOrEmpty(RequestMessage)) return;

            Messages.Add(new ChatResponseMessageDTO("user", RequestMessage));
            OnPropertyChanged(nameof(Messages));
            RequestMessage = "";

            var systemMessage = new ChatResponseMessageDTO("system", _customization);
            ObservableCollection<ChatResponseMessageDTO> RequestMessages = new(Messages.ToList());
            RequestMessages.Insert(0, systemMessage);

            var request = new ChatRequestDTO(Model, RequestMessages.ToList(), false);

            var response = await _ollamaChatService.GenerateResponseAsync(ChatRequestMapper.MapToEntity(request));

            Messages.Add(new ChatResponseMessageDTO("assistant", response.Message.Content));
            OnPropertyChanged(nameof(Messages));

            FocusEntryMessage();
        }
    }
}
