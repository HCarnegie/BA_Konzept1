using System;
using System.Collections.Generic;
using System.Web.Http;
using Ninject;
using BA_Konzept.Domain.Abstract;
using BA_Konzept.Domain.Concrete;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace BA_Konzept3.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private readonly IKernel _kernel;

		public NinjectDependencyResolver(IKernel kernelParam)
		{
			this._kernel = kernelParam;
			AddBindings();
		}

		public IDependencyScope BeginScope()
		{
			return this;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public object GetService(Type serviceType)
		{
			return this._kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return this._kernel.GetAll(serviceType);
		}

		private void AddBindings()
		{
			this._kernel.Bind<IProductRepository>().To<ProductRepository>();
			this._kernel.Bind<IProducttypeRepository>().To<ProducttypeRepository>();
		}
	}
}