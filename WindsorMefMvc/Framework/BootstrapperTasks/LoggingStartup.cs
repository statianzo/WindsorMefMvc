using System;
using log4net.Config;

namespace WindsorMefMvc.Web.Framework.BootstrapperTasks
{
	public class LoggingStartup:IBootstrapperTask
	{
		public int Order
		{
			get { return -10; }
		}

		public void Execute()
		{
			XmlConfigurator.Configure();
		}
	}
}