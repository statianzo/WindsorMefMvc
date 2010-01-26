using Castle.Windsor;
namespace WindsorMefMvc.Services
{
	public interface IMvcPackage:IWindsorInstaller
	{
		void RegisterRoutes(IRouteRegistrationStrategy routeRegistrationStrategy);
	}
}