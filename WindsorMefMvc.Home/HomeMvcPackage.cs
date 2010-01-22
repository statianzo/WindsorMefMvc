using System;
using System.ComponentModel.Composition;
using System.Web.Routing;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Home
{
	[Export(typeof (IMvcPackage))]
	public class HomeMvcPackage:IMvcPackage
	{
		public void RegisterRoutes(RouteCollection routes)
		{

		}
	}
}