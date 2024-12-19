using FluxuMente.Application.Abstractions;
using FluxuMente.Presentation.Navigation;
using FluxuMente.Presentation.ViewModels;

namespace FluxuMente.Presentation.Views;

public partial class InstallGuideView : ContentPage
{
    private bool _hasLoadedOnce = false;

    public InstallGuideView(INavigationService navigationService, IOllamaChatService ollamaChatService, IServiceProvider serviceProvider)
	{
		InitializeComponent();

        BindingContext = new InstallGuideViewModel(navigationService, ollamaChatService, serviceProvider);
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is InstallGuideViewModel viewModel && !_hasLoadedOnce)
        {
            viewModel.TestState();
            _hasLoadedOnce = true;
        }
    }
}