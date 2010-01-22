using System.Reflection;
using System.Web.Mvc;
using Spark.FileSystem;
using Spark.Web.Mvc;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Impl
{
	public class ViewEngineRegistrationStrategy : IViewEngineRegistrationStrategy
	{
		public void RegisterViewEngine(Assembly assembly)
		{
			var engine = new SparkViewFactory
			{
				ViewFolder = new EmbeddedViewFolder(assembly, assembly.GetName().Name + ".Views")
			};
			ViewEngines.Engines.Add(engine);
		}
	}
}