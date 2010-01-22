using System.Reflection;
using System.Web.Mvc;
using Spark.FileSystem;
using Spark.Web.Mvc;
using WindsorMefMvc.Services;
using Spark.Web.Mvc.Wrappers;

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