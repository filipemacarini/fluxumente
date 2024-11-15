namespace FluxuMente.Application.Abstractions
{
    public interface INavigationService
    {
        Task NavigateToAsync(Page page);
        Task GoBackAsync();
    }
}
