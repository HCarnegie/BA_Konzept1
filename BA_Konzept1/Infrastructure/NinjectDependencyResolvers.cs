using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using BA_Konzept.Domain.Abstract;
using BA_Konzept.Domain.Concrete;
using System.Linq;
using System.Web;

namespace BA_Konzept1.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel kernel;

		public NinjectDependencyResolver(IKernel kernelParam)
		{
			kernel = kernelParam;
			AddBindings();
		}

		public object GetService(Type serviceType)
		{
			return kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return kernel.GetAll(serviceType);
		}

		private void AddBindings()
		{
			kernel.Bind<IProductRepository>().To<ProductRepository>();
			kernel.Bind<IProducttypeRepository>().To<ProducttypeRepository>();
		}
	}
}