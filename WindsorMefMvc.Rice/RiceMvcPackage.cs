using System.ComponentModel.Composition;
using System.Web.Routing;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Rice
{
	[Export(typeof (IMvcPackage))]
	public class RiceMvcPackage : IMvcPackage
	{
		public void RegisterRoutes(RouteCollection routes)
		{
		}
	}
}