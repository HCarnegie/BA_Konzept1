using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BA_Konzept3.Infrastructure;

namespace BAKonzept1
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config) {
			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			config.Formatters.Remove(config.Formatters.XmlFormatter);
			//config.DependencyResolver = new NinjectDependencyResolver();

			GlobalConfiguration.Configuration.Formatters.JsonFormatter
					.SerializerSettings.ReferenceLoopHandling =
				Newtonsoft.Json.ReferenceLoopHandling.Ignore;
		}
	}
}