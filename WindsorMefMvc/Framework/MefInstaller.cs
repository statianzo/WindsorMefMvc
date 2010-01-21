using System;
using Castle.MicroKernel;
using Castle.Windsor;
using System.ComponentModel.Composition.Hosting;
namespace WindsorMefMvc.Web.Framework
{
	public class MefInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			var directory = Environment.CurrentDirectory;

			var compContainer = new CompositionContainer(new DirectoryCatalog(directory));
			var installers = compContainer.GetExportedValues<IWindsorInstaller>("ComponentInstaller");

			foreach (var installer in installers)
			{
				installer.Install(container, store);
			}
		}
	}
}