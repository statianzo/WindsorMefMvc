using System.ComponentModel.Composition;
using System.Web.Mvc;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
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
			container.Register(
				Component.For<IViewEngineRegistrationStrategy>()
					.ImplementedBy<ViewEngineRegistrationStrategy>().
					LifeStyle.Transient);
			container.AddComponentLifeStyle<IRouteRegistrationStrategy, ContainerNameRouteRegistrationStrategy>(
				LifestyleType.Transient);
		}
	}
}