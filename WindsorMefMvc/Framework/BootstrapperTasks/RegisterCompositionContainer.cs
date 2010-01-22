using System.ComponentModel.Composition.Hosting;
using Castle.Windsor;

namespace WindsorMefMvc.Web.Framework.BootstrapperTasks
{
	public class RegisterCompositionContainer : IBootstrapperTask
	{
		private const string Directory = "bin";
		private readonly IWindsorContainer _windsorContainer;

		public RegisterCompositionContainer(IWindsorContainer windsorContainer)
		{
			_windsorContainer = windsorContainer;
		}

		public int Order
		{
			get { return -3; }
		}

		public void Execute()
		{
			var catalog = new DirectoryCatalog(Directory, "WindsorMefMvc.*.dll");
			var compContainer = new CompositionContainer(catalog);
			_windsorContainer.Kernel.AddComponentInstance<CompositionContainer>(compContainer);
		}
	}
}