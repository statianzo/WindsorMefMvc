using System.Reflection;

namespace WindsorMefMvc.Services
{
	public interface IViewEngineRegistrationStrategy
	{
		void RegisterViewEngine(Assembly assembly);
	}
}