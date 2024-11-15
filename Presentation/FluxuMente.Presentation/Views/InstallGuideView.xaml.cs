using FluxuMente.Application.ViewModels;
using FluxuMente.Application.Abstractions;

namespace FluxuMente.Presentation.Views;

public partial class InstallGuideView : ContentPage
{
	public InstallGuideView(INavigationService navigationService, IOllamaChatService ollamaChatService)
	{
		InitializeComponent();

        BindingContext = new InstallGuideViewModel(navigationService, ollamaChatService);
	}
}