using System.ComponentModel.Composition;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using log4net;

namespace WindsorMefMvc.Web.Framework
{
	public class Bootstrapper
	{
		[Export(typeof (IWindsorContainer))]
		private WindsorContainer _container;

		public Bootstrapper()
		{
			ConfigureContainer();
		}

		private readonly ILog _logger = LogManager.GetLogger(typeof (Bootstrapper));
		public void Run()
		{
			var tasks = _container.ResolveAll<IBootstrapperTask>().OrderBy(x=>x.Order);
			foreach (var task in tasks)
			{
				_logger.InfoFormat("Executing task: {0}",task.GetType().Name);
				task.Execute();
			}
		}
		private void ConfigureContainer()
		{
			_container = new WindsorContainer();
			_container.Kernel.AddComponentInstance<IWindsorContainer>(_container);
			_container.Register(AllTypes.Of<IBootstrapperTask>().FromAssembly(typeof (Bootstrapper).Assembly));
		}
	}
}