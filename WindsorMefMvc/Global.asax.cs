using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Spark;
using Spark.Web.Mvc;
using WindsorMefMvc.Services;
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
			container.Kernel.AddComponentInstance<IWindsorContainer>(container);
			container.Install(new MefInstaller());


			var controllerRegister = container.Resolve<IControllerRegistrationStrategy>();
			controllerRegister.Register(typeof (MvcApplication).Assembly);

		    var viewengineRegister = container.Resolve<IViewEngineRegistrationStrategy>();
            viewengineRegister.RegisterViewEngine(new SparkViewFactory());
            

			ControllerBuilder.Current.SetControllerFactory(container.Resolve<IControllerFactory>());
		}
	}
}