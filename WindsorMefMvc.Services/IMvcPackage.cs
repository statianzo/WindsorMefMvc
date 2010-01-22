using Castle.Windsor;

namespace WindsorMefMvc.Services
{
    public interface IMvcPackage
    {
        void Register(IWindsorContainer container);
    }
}