namespace FluxuMente.Presentation.Navigation
{
    public interface INavigationService
    {
        Task NavigateToAsync(Page page);
        Task GoBackAsync();
    }
}
