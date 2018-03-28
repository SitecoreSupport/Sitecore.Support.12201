namespace Sitecore.Support.XA.Foundation.IoC.ServiceCollection
{
  using Microsoft.Extensions.DependencyInjection;
  using Sitecore.DependencyInjection;
  using Sitecore.XA.Feature.Navigation.Repositories.Navigation;

  public class RegisterSupportNavigationRepository : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.AddSingleton<INavigationRepository, Sitecore.Support.XA.Feature.Navigation.Repositories.Navigation.NavigationRepository>();
    }
  }
}