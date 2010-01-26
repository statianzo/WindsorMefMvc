using System;
using System.ComponentModel.Composition;
using Castle.MicroKernel;
using Castle.Windsor;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Rice
{
	[Export(typeof (IMvcPackage))]
	public class RiceMvcPackage : IMvcPackage
	{
		public void RegisterRoutes(IRouteRegistrationStrategy routeRegistrationStrategy)
		{
			routeRegistrationStrategy.MapRoute(
				"RiceController",
				"Rice/{action}/{id}",
				new {controller="rice", action = "Index", id = ""});
		}

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
		}
	}
}