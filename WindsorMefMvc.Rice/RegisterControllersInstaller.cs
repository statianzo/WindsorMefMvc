using System.ComponentModel.Composition;
using Castle.MicroKernel;
using Castle.Windsor;

namespace WindsorMefMvc.Rice
{
	[Export(typeof (IWindsorInstaller))]
	public class RegisterControllersInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
		}
	}
}