using FluxuMente.Application.Abstractions;
using FluxuMente.Presentation.ViewModels;

namespace FluxuMente.Presentation.Views;

public partial class ChatView : ContentPage
{
	public ChatView(IOllamaChatService ollamaChatService, string customization)
	{
		InitializeComponent();

		BindingContext = new ChatViewModel(ollamaChatService, customization, this);
	}
}