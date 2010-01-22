using System.Web.Mvc;
using Castle.Windsor;

namespace WindsorMefMvc.Web.Framework.BootstrapperTasks
{
	public class SetControllerFactoryTask : IBootstrapperTask
	{
		private readonly IWindsorContainer _container;

		public SetControllerFactoryTask(IWindsorContainer container)
		{
			_container = container;
		}

		public int Order
		{
			get { return 0; }
		}

		public void Execute()
		{
			var factory = _container.Resolve<IControllerFactory>();
			ControllerBuilder.Current.SetControllerFactory(factory);
		}
	}
}