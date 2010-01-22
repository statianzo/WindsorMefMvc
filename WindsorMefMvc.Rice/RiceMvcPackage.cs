using System.ComponentModel.Composition;
using System.Web.Routing;
using WindsorMefMvc.Services;
using Castle.Windsor;

namespace WindsorMefMvc.Rice
{
	[Export(typeof (IMvcPackage))]
	public class RiceMvcPackage : IMvcPackage
	{
		private readonly IWindsorContainer _container;

		[ImportingConstructor]
		public RiceMvcPackage(IWindsorContainer container)
		{
			_container = container;
		}

		public void RegisterRoutes(RouteCollection routes)
		{
		}
	}
}