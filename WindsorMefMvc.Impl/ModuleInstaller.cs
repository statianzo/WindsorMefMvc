using System.ComponentModel.Composition;
using System.Web.Mvc;
using Castle.Core;
using Castle.MicroKernel;
using Castle.Windsor;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Impl
{
	[Export(typeof (IWindsorInstaller))]
	public class ModuleInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddComponent<IControllerFactory, WindsorControllerFactory>();
			container.AddComponentLifeStyle<IControllerRegistrationStrategy, UppercaseControllerRegistrationStrategy>(
				LifestyleType.Transient);
		}
	}
}