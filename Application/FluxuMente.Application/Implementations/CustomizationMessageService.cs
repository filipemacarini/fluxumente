using FluxuMente.Application.Abstractions;
using FluxuMente.Application.DTOs;
using FluxuMente.Application.Mappers;
using FluxuMente.Domain.Entities;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

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
                new() { Id = 0, Title = "Padrão", Content = "" },
                new() { Id = 1, Title = "Irmão", Content = "Default" },
                new() { Id = 2, Title = "Irmã", Content = "Default" },
                new() { Id = 3, Title = "Pai", Content = "Default" },
                new() { Id = 4, Title = "Mãe", Content = "Default" },
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
            message.Id = customizationMessages.Max(m => m.Id) + 1;
            int index = 2;
            while (customizationMessages.Exists(msg => msg.Title == message.Title))
            {
                string pattern = @" \(\d+\)";
                string cleanTitle = message.Title;
                if (customizationMessages.Exists(msg => msg.Title == message.Title))
                    cleanTitle = Regex.Replace(message.Title, pattern, "");
                message.Title = $"{cleanTitle} ({index++})";
            }
            customizationMessages.Add(message);
            await SaveMessagesAsync(customizationMessages);
        }

        public async Task RemoveMessageAsync(int id)
        {
            var customizationMessages = await GetAllMessagesAsync();
            var message = await GetMessageByIdAsync(id);

            if (message != null)
            {
                customizationMessages.RemoveAll(m => m.Id == message.Id);
                await SaveMessagesAsync(customizationMessages);
            }
        }

        public async Task UpdateMessageAsync(CustomizationMessageDTO messageUpdated)
        {
            var customizationMessages = await GetAllMessagesAsync();
            var message = await GetMessageByIdAsync(messageUpdated.Id);

            if (message != null)
            {
                int index = customizationMessages.FindIndex(msg => msg.Id == messageUpdated.Id);
                customizationMessages[index].Content = messageUpdated.Content;
                customizationMessages[index].Title = messageUpdated.Title;
                await SaveMessagesAsync(customizationMessages);
            }
        }

        private async Task<CustomizationMessageDTO?> GetMessageByIdAsync(int id)
        {
            var customizationMessages = await GetAllMessagesAsync();
            var message = customizationMessages.Where(msg => msg.Id == id).FirstOrDefault();
            return message;
        } 

        private async Task CheckFiles()
        {
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);

            if (!File.Exists(_filePath))
                await SaveMessagesAsync(_defaultMessages);
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
