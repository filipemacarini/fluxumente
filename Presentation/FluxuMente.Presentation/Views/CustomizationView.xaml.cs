using FluxuMente.Application.Abstractions;
using FluxuMente.Application.ViewModels;
using FluxuMente.Presentation.Navigation;

namespace FluxuMente.Presentation.Views;

public partial class CustomizationView : ContentPage
{
	public CustomizationView(INavigationService navigationService, ICustomizationMessageService customizationMessageService)
	{
		InitializeComponent();

		BindingContext = new CustomizationViewModel(navigationService, customizationMessageService);
	}
}