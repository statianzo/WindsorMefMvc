using System.Collections.Generic;
using System.Web.Mvc;
using WindsorMefMvc.Services;

namespace WindsorMefMvc.Impl
{
    public class ViewEngineRegistrationStrategy : IViewEngineRegistrationStrategy
    {


        public void RegisterViewEngine(IViewEngine engine)
        {
            ViewEngines.Engines.Add(engine);
        }
    }
}