using FluxuMente.Application.Abstractions;
using FluxuMente.Presentation.Navigation;
using FluxuMente.Presentation.ViewModels;

namespace FluxuMente.Presentation.Views;

public partial class CustomizationView : ContentPage
{
	public CustomizationView(INavigationService navigationService, ICustomizationMessageService customizationMessageService, IServiceProvider serviceProvider)
	{
		InitializeComponent();

		BindingContext = new CustomizationViewModel(navigationService, customizationMessageService, serviceProvider);
	}
}