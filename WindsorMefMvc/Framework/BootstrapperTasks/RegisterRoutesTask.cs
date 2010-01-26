using System.Web.Mvc;
using System.Web.Routing;

namespace WindsorMefMvc.Web.Framework.BootstrapperTasks
{
	public class RegisterRoutesTask : IBootstrapperTask
	{
		public int Order { get; protected set; }

		public void Execute()
		{
			RouteCollection routes = RouteTable.Routes;
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
		}
	}
}