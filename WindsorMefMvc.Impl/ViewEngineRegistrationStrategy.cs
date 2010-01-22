using System.Reflection;
using Spark.Web.Mvc;
using Spark.Web.Mvc.Wrappers;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Impl
{
	public class ViewEngineRegistrationStrategy : IViewEngineRegistrationStrategy
	{
		private readonly IViewFolderContainer _viewFolderContainer;

		public ViewEngineRegistrationStrategy(IViewFolderContainer viewFolderContainer)
		{
			_viewFolderContainer = viewFolderContainer;
		}

		public void RegisterViewEngine(Assembly assembly)
		{
			_viewFolderContainer.AddEmbeddedResources(assembly, assembly.GetName().Name + ".Views");
		}
	}
}