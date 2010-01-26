using System.ComponentModel.Composition;
using Castle.MicroKernel;
using Castle.Windsor;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Home
{
	[Export(typeof (IMvcPackage))]
	public class HomeMvcPackage : IMvcPackage
	{
		public void RegisterRoutes(IRouteRegistrationStrategy routeRegistrationStrategy)
		{
			routeRegistrationStrategy.MapRoute(
				"HomeController",
				"Home/{action}/{id}",
				new {controller = "home", action = "Index", id = ""});
			routeRegistrationStrategy.MapRoute(
				"Default",
				"{action}/{id}",
				new {controller = "Home", action = "Index", id = ""});
		}

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
		}
	}
}