using System.Web.Mvc;

namespace WindsorMefMvc.Services
{
    public interface IViewEngineRegistrationStrategy
    {
        void RegisterViewEngine(IViewEngine engine);
    }
}