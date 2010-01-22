using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using Castle.MicroKernel;
using Castle.Windsor;

namespace WindsorMefMvc.Web.Framework
{
	public class MefInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			string directory = "bin";

			var compContainer = new CompositionContainer(new DirectoryCatalog(directory, "WindsorMefMvc.*.dll"));
			IEnumerable<Lazy<IWindsorInstaller>> installers = compContainer.GetExports<IWindsorInstaller>();


			foreach (var installer in installers)
			{
				installer.Value.Install(container, store);
			}
		}
	}
}