using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Spark.Web.Mvc;
using WindsorMefMvc.Web.Framework;

namespace WindsorMefMvc.Web
{
	public class MvcApplication : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new {controller = "Home", action = "Index", id = ""} // Parameter defaults
				);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);

			var container = new WindsorContainer();
			container.Install(new MefInstaller());

			container.Register(
				AllTypes.Of<IController>()
				.FromAssembly(typeof (MvcApplication).Assembly)
				.Configure(x => x.Named(x.ServiceType.Name.ToUpperInvariant()).LifeStyle.Transient));

			SparkEngineStarter.RegisterViewEngine(ViewEngines.Engines);

			ControllerBuilder.Current.SetControllerFactory(container.Resolve<IControllerFactory>());
		}
	}
}