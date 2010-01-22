using System.ComponentModel.Composition;
using System.Web;
using Castle.Windsor;
using WindsorMefMvc.Web.Framework;

namespace WindsorMefMvc.Web
{
	public class MvcApplication : HttpApplication
	{

		protected void Application_Start()
		{
			new Bootstrapper().Run();
		}
	}
}