using FluxuMente.Presentation.ViewModels;

namespace FluxuMente.Presentation.Views;

public partial class CustomizationMessagesManagerView : ContentPage
{
	public CustomizationMessagesManagerView()
	{
		InitializeComponent();

		BindingContext = new CustomizationMessagesManagerViewModel();
	}
}