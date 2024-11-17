using FluxuMente.Application.ViewModels;
using FluxuMente.Application.Abstractions;
using FluxuMente.Presentation.Navigation;

namespace FluxuMente.Presentation.Views;

public partial class InstallGuideView : ContentPage
{
	public InstallGuideView(INavigationService navigationService, IOllamaChatService ollamaChatService, IServiceProvider serviceProvider)
	{
		InitializeComponent();

        BindingContext = new InstallGuideViewModel(navigationService, ollamaChatService, serviceProvider);
	}
}