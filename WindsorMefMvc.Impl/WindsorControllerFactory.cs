using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;
using Castle.Windsor;

namespace WindsorMefMvc.Impl
{
	public class WindsorControllerFactory : IControllerFactory
	{
		private readonly IWindsorContainer _container;

		public WindsorControllerFactory(IWindsorContainer container)
		{
			_container = container;
		}

		public IController CreateController(RequestContext requestContext, string controllerName)
		{
			try
			{
				IWindsorContainer container = _container;
				RouteValueDictionary routeValues = requestContext.RouteData.Values;
				if (routeValues.ContainsKey("container"))
					container = _container.GetChildContainer(routeValues["container"].ToString());
				return container.Resolve<IController>(controllerName.ToUpperInvariant() + "CONTROLLER");
			}
			catch (ComponentNotFoundException ex)
			{
				requestContext.HttpContext.AddError(new HttpException((int) HttpStatusCode.NotFound, ex.Message, ex));
				requestContext.HttpContext.ApplicationInstance.CompleteRequest();
				return null;
			}
		}

		public void ReleaseController(IController controller)
		{
			_container.Kernel.ReleaseComponent(controller);
		}
	}
}