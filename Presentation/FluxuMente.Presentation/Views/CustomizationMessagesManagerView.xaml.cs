using FluxuMente.Application.Abstractions;
using FluxuMente.Presentation.ViewModels;

namespace FluxuMente.Presentation.Views;

public partial class CustomizationMessagesManagerView : ContentPage
{
	public CustomizationMessagesManagerView(ICustomizationMessageService customizationMessageService)
	{
		InitializeComponent();

		BindingContext = new CustomizationMessagesManagerViewModel(customizationMessageService);
	}
}