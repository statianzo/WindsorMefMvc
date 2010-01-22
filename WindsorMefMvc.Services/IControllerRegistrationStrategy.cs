using System.Reflection;

namespace WindsorMefMvc.Services
{
	public interface IControllerRegistrationStrategy
	{
		void Register(Assembly assembly);
	}
}