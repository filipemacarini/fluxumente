using FluxuMente.Application.Abstractions;
using FluxuMente.Presentation.Navigation;
using FluxuMente.Presentation.ViewModels;

namespace FluxuMente.Presentation.Views;

public partial class CustomizationView : ContentPage
{
	private CustomizationViewModel _viewModel;
	public CustomizationView(INavigationService navigationService, ICustomizationMessageService customizationMessageService, IServiceProvider serviceProvider)
	{
		InitializeComponent();

        _viewModel = new CustomizationViewModel(navigationService, customizationMessageService, serviceProvider);
        BindingContext = _viewModel;
	}
}