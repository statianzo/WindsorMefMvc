using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Castle.Windsor;
using WindsorMefMvc.Services;

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
			var controllerRegistrationStrategy = _windsorContainer.Resolve<IControllerRegistrationStrategy>();
			var viewRegistrationStrategy = _windsorContainer.Resolve<IViewEngineRegistrationStrategy>();
			foreach (var package in packages)
			{
				IMvcPackage value = package.Value;
				Assembly assembly = value.GetType().Assembly;
				controllerRegistrationStrategy.Register(assembly);
				viewRegistrationStrategy.RegisterViewEngine(assembly);
			}
		}
	}
}