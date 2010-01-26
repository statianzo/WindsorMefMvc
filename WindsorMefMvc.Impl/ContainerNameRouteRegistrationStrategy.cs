using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Impl
{
	public class ContainerNameRouteRegistrationStrategy : IRouteRegistrationStrategy
	{
		private readonly IWindsorContainer _container;
		private readonly RouteCollection _routes;

		public ContainerNameRouteRegistrationStrategy(IWindsorContainer container)
		{
			_container = container;
			_routes = RouteTable.Routes;
		}

		public void MapRoute(string name, string url, object defaults, object constraints)
		{
			var values = new RouteValueDictionary(defaults);
			var constraintDictionary = new RouteValueDictionary(constraints);
			values.Add("container", _container.Name);
			var route = new Route(url, values, constraintDictionary, new MvcRouteHandler());
			_routes.Add(name, route);
		}

		public void MapRoute(string name, string url, object defaults)
		{
			MapRoute(name, url, defaults, null);
		}

		public void MapRoute(string name, string url)
		{
			MapRoute(name, url, null);
		}
	}
}