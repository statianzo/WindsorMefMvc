using System.ComponentModel.Composition;
using Castle.Windsor;
using Spark.FileSystem;
using Spark.Web.Mvc;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Rice
{
    [Export(typeof (IMvcPackage))]
    public class RegisterControllersInstaller : IMvcPackage
    {
        public void Register(IWindsorContainer container)
        {
            var controllerRegister = container.Resolve<IControllerRegistrationStrategy>();
            controllerRegister.Register(typeof (RegisterControllersInstaller).Assembly);

            var viewengineRegister = container.Resolve<IViewEngineRegistrationStrategy>();
            var engine = new SparkViewFactory
                             {
                                 ViewFolder = new EmbeddedViewFolder(typeof (RegisterControllersInstaller).Assembly,
                                                                     "WindsorMefMvc.Rice.Views")
                             };
            viewengineRegister.RegisterViewEngine(engine);
        }
    }
}