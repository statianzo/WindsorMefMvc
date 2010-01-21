using System.ComponentModel.Composition;
using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.Windsor;

namespace WindsorMefMvc.Impl
{
	[Export("ComponentInstaller")]
	public class ModuleInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddComponent<IControllerFactory, WindsorControllerFactory>();
		}
	}
}