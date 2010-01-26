namespace WindsorMefMvc.Services
{
	public interface IRouteRegistrationStrategy
	{
		void MapRoute(string name, string url, object defaults, object constraints);
		void MapRoute(string name, string url, object defaults);
		void MapRoute(string name, string url);
	}

}