using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Castle.Windsor;
using WindsorMefMvc.Services;
using Castle.Windsor.Configuration.Interpreters;

namespace WindsorMefMvc.Web.Framework.BootstrapperTasks
{
	public class LoadMvcPackagesTask : IBootstrapperTask
	{
		private readonly IWindsorContainer _windsorContainer;

		public LoadMvcPackagesTask(IWindsorContainer windsorContainer)
		{
			_windsorContainer = windsorContainer;
		}

		public int Order { get; set; }

		public void Execute()
		{
			var compositionContainer = _windsorContainer.Resolve<CompositionContainer>();
			IEnumerable<Lazy<IMvcPackage>> packages = compositionContainer.GetExports<IMvcPackage>();
			foreach (var package in packages)
			{
				IMvcPackage value = package.Value;
				Assembly assembly = value.GetType().Assembly;

				var childContainer = GetChildContainer(assembly);
				childContainer.Install(value);

				var controllerRegistrationStrategy = childContainer.Resolve<IControllerRegistrationStrategy>();
				var viewRegistrationStrategy = childContainer.Resolve<IViewEngineRegistrationStrategy>();
				var routeRegistrationStrategy = childContainer.Resolve<IRouteRegistrationStrategy>();

				controllerRegistrationStrategy.Register(assembly);
				viewRegistrationStrategy.RegisterViewEngine(assembly);
				value.RegisterRoutes(routeRegistrationStrategy);
			}
		}

		private IWindsorContainer GetChildContainer(Assembly assembly)
		{
			var name = assembly.GetName().Name.Replace(".","");
			var childContainer = _windsorContainer.GetChildContainer(name);
			if (childContainer == null)
			{
				childContainer = new WindsorContainer(name, _windsorContainer, new XmlInterpreter());
				childContainer.Kernel.AddComponentInstance<IWindsorContainer>(childContainer);
			}
			return childContainer;
		}
	}
}