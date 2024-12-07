using FluxuMente.Application.Abstractions;
using FluxuMente.Application.DTOs;
using FluxuMente.Application.Mappers;
using FluxuMente.Domain.Entities;
using System.Reflection;
using System.Text.Json;

namespace FluxuMente.Application.Implementations
{
    public class CustomizationMessageService : ICustomizationMessageService
    {
        private readonly CustomizationMessageMapper _messageMapper;

        private readonly string _appDataPath;
        private readonly string _folderPath;
        private readonly string _filePath;
        private readonly List<CustomizationMessage> _defaultMessages;

        public CustomizationMessageService()
        {
            _messageMapper = new CustomizationMessageMapper();

            _appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _folderPath = Path.Combine(_appDataPath, "FluxuMente");
            _filePath = Path.Combine(_folderPath, "CustomizationMessages.json");

            _defaultMessages = new()
            {
                new() { Title = "Padrão", Content = "" },
                new() { Title = "Irmão", Content = "Default" },
                new() { Title = "Irmã", Content = "Default" },
                new() { Title = "Pai", Content = "Default" },
                new() { Title = "Mãe", Content = "Default" },
            };
        }

        public async Task<List<CustomizationMessageDTO>> GetAllMessagesAsync()
        {
            await CheckFiles();

            var json = await File.ReadAllTextAsync(_filePath);
            await using var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var customizationMessages = JsonSerializer.Deserialize<List<CustomizationMessage>>(stream);
            var customizationMessagesDTO = _messageMapper.MapToDtoList(customizationMessages);
            return customizationMessagesDTO;
        }

        public async Task AddMessageAsync(CustomizationMessageDTO message)
        {
            var customizationMessages = await GetAllMessagesAsync();
            customizationMessages.Add(message);
            await SaveMessagesAsync(customizationMessages);
        }

        public async Task RemoveMessageAsync(string title)
        {
            var customizationMessages = await GetAllMessagesAsync();
            var message = await GetMessageByTitleAsync(title);

            if (message != null)
            {
                customizationMessages.Remove(message);
                await SaveMessagesAsync(customizationMessages);
            }
        }

        public async Task UpdateMessageAsync(CustomizationMessageDTO messageUpdated)
        {
            var customizationMessages = await GetAllMessagesAsync();
            var message = await GetMessageByTitleAsync(messageUpdated.Title);

            if (message != null)
            {
                customizationMessages[customizationMessages
                    .FindIndex(msg => msg.Title.Equals(message.Title, StringComparison.OrdinalIgnoreCase))].Content = messageUpdated.Content;
                await SaveMessagesAsync(customizationMessages);
            }
        }

        private async Task<CustomizationMessageDTO?> GetMessageByTitleAsync(string title)
        {
            var customizationMessages = await GetAllMessagesAsync();
            var message = customizationMessages.Find(msg => msg.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            return message;
        } 

        private async Task CheckFiles()
        {
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);

            if (!File.Exists(_filePath))
            {
                await SaveMessagesAsync(_defaultMessages);
            }
        }

        private async Task SaveMessagesAsync(List<CustomizationMessage> messages)
        {
            using FileStream createStream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(createStream, messages, new JsonSerializerOptions() { WriteIndented = true });
            await createStream.DisposeAsync();
        }

        private async Task SaveMessagesAsync(List<CustomizationMessageDTO> messages)
        {
            using FileStream createStream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(createStream, _messageMapper.MapToEntityList(messages), new JsonSerializerOptions() { WriteIndented = true });
            await createStream.DisposeAsync();
        }
    }
}
