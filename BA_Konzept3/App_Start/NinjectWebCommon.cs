using System;
using System.Web;
using System.Web.Http;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;
using BA_Konzept3.Infrastructure;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BA_Konzept3.App_Start.NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(BA_Konzept3.App_Start.NinjectWebCommon), "Stop")]

namespace BA_Konzept3.App_Start
{
	public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
	        IKernel container = null;
	        
			bootstrapper.Initialize(() =>
			{
				container = CreateKernel();
				return container;
			});

			ConfigurationEF();
		}
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
			//System.Web.MVC..DependencyResolver.SetResolver(new
			//	NinjectDependencyResolver(kernel));
	        var resolver = new NinjectDependencyResolver(kernel);
	        GlobalConfiguration.Configuration.DependencyResolver = resolver;
		}


		private static void ConfigurationEF()
		{
			
		}
	}
}
