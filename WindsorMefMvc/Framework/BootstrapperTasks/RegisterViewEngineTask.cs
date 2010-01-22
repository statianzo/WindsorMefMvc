using System.Web.Mvc;
using Castle.Windsor;
using Spark.Web.Mvc;
using Spark.Web.Mvc.Wrappers;

namespace WindsorMefMvc.Web.Framework.BootstrapperTasks
{
	public class RegisterViewEngineTask : IBootstrapperTask
	{
		private readonly IWindsorContainer _container;

		public RegisterViewEngineTask(IWindsorContainer container)
		{
			_container = container;
		}

		public int Order { get { return -1; } }

		public void Execute()
		{
			var sparkViewFactory = new SparkViewFactory();
			_container.Kernel.AddComponentInstance<IViewFolderContainer>(sparkViewFactory);
			ViewEngines.Engines.Add(sparkViewFactory);
		}
	}
}