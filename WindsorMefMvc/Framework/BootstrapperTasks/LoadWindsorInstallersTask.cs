using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using Castle.Windsor;

namespace WindsorMefMvc.Web.Framework.BootstrapperTasks
{
	public class LoadWindsorInstallersTask : IBootstrapperTask
	{
		private readonly IWindsorContainer _windsorContainer;

		public LoadWindsorInstallersTask(IWindsorContainer windsorContainer)
		{
			_windsorContainer = windsorContainer;
		}

		public int Order { get { return -2; } }

		public void Execute()
		{
			var compositionContainer = _windsorContainer.Resolve<CompositionContainer>();
			IEnumerable<Lazy<IWindsorInstaller>> installers = compositionContainer.GetExports<IWindsorInstaller>();

			foreach (var installer in installers)
				_windsorContainer.Install(installer.Value);
		}
	}
}