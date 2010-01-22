using System.Web.Routing;

namespace WindsorMefMvc.Services
{
	public interface IMvcPackage
	{
		void RegisterRoutes(RouteCollection routes);
	}
}