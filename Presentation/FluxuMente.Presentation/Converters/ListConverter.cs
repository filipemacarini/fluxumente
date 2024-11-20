using FluxuMente.Application.DTOs;
using Markdig;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.Globalization;

namespace FluxuMente.Presentation.Converters;

public class ListConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var list = value as ObservableCollection<ChatResponseMessageDTO>;

        var returnList = new ObservableCollection<object>(
            list.Select((message, index) => new
            {
                Role = message.Role,
                Content = message.Content,
                ContentHtml = Markdown.ToHtml(message.Content).Trim(),
                Columns = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(message.Role == "user" ? 0.3 : 0.7, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(message.Role == "user" ? 0.7 : 0.3, GridUnitType.Star) }
                },
                Side = (message.Role == "user" ? 1 : 0),
                SideLayout = (message.Role == "user" ? LayoutOptions.End : LayoutOptions.Start),
                Corner = (message.Role == "user" ? new RoundRectangle() { CornerRadius = new(24, 24, 24, 0) } : new RoundRectangle() { CornerRadius = new(24, 24, 0, 24) }),
                Spacing = (index == list.Count - 1 ? new Thickness(0, 0, 0, 0) : new Thickness(0, 0, 0, 12))
            })
        );

        return returnList;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
