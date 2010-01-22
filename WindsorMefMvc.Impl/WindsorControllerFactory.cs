using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace WindsorMefMvc.Impl
{
	public class WindsorControllerFactory : IControllerFactory
	{
		private readonly IKernel _kernel;

		public WindsorControllerFactory(IKernel kernel)
		{
			_kernel = kernel;
		}

		public IController CreateController(RequestContext requestContext, string controllerName)
		{
			try
			{
				return _kernel.Resolve<IController>(controllerName.ToUpperInvariant() + "CONTROLLER");
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
			_kernel.ReleaseComponent(controller);
		}
	}
}