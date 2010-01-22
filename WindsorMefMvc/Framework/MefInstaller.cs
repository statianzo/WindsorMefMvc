using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Castle.MicroKernel;
using Castle.Windsor;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Web.Framework
{
	public class MefInstaller : IWindsorInstaller
	{
		private const string Directory = "bin";
		private readonly CompositionContainer _compContainer;

		public MefInstaller()
		{
			_compContainer = new CompositionContainer(new DirectoryCatalog(Directory, "WindsorMefMvc.*.dll"));
		}

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			LoadWindsorInstallers(container, store);
			LoadMvcPackages(container);
		}

		private void LoadMvcPackages(IWindsorContainer container)
		{
			IEnumerable<Lazy<IMvcPackage>> packages = _compContainer.GetExports<IMvcPackage>();
			var controllerRegistrationStrategy = container.Resolve<IControllerRegistrationStrategy>();
			var viewRegistrationStrategy = container.Resolve<IViewEngineRegistrationStrategy>();
			foreach (var package in packages)
			{
				IMvcPackage value = package.Value;
				Assembly assembly = value.GetType().Assembly;
				controllerRegistrationStrategy.Register(assembly);
				viewRegistrationStrategy.RegisterViewEngine(assembly);
			}
		}

		private void LoadWindsorInstallers(IWindsorContainer container, IConfigurationStore store)
		{
			IEnumerable<Lazy<IWindsorInstaller>> installers = _compContainer.GetExports<IWindsorInstaller>();


			foreach (var installer in installers)
				installer.Value.Install(container, store);
		}
	}
}