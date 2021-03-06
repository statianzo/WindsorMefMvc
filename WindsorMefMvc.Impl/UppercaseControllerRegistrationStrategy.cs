using System;
using System.Reflection;
using System.Web.Mvc;
using Castle.Windsor;
using WindsorMefMvc.Services;
using Castle.MicroKernel.Registration;

namespace WindsorMefMvc.Impl
{
	public class UppercaseControllerRegistrationStrategy:IControllerRegistrationStrategy
	{
		private readonly IWindsorContainer _container;

		public UppercaseControllerRegistrationStrategy(IWindsorContainer container)
		{
			_container = container;
		}

		public void Register(Assembly assembly)
		{
			_container.Register(
				AllTypes.Of<IController>()
					.FromAssembly(assembly)
					.Configure(x => x.Named(x.ServiceType.Name.ToUpperInvariant())
					                	.LifeStyle.Transient));
		}
	}
}