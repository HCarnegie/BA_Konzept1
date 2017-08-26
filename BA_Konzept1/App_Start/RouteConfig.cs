using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BA_Konzept1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


			 
			// Lists the first page of products from all categories
   //         routes.MapRoute(null,
			//		"",
			//		new
			//		{
			//			Controller = "Producttype",
			//			action = "List",
			//			category = (string)null,
			//			page = 1
			//		}
			//);

			// Page2 
			// List the specified page (in this case page 2), showing items from all categories of products from all categories 
			routes.MapRoute(null,
				"Page{page}",
				new
				{
					controller = "Product",
					action = "List",
					category = (string)null,
				},
				new
				{
					page = @"\d+"
				}
			);

			// Soccer
			// Shows the first page of items from a specified category (in this case, the Soccer category)
			routes.MapRoute(null,
				"{category}",
				new
				{
					controller = "Product",
					action = "List",
					page = 1,
				}
			);

			// Soccer/Page2
			// Shows the specified page (in this case, page 2) of items from the specified category (in this case, Soccer)
			routes.MapRoute(null,
				"{category}/Page{page}",
				new
				{
					controller = "Product",
					action = "List"
				},
				new
				{
					page = @"\d+"
				}
			);

			// Home default /
		   routes.MapRoute(
			   name: "Default",
			   url: "{controller}/{action}/{id}",
			   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
		   );

			routes.MapRoute(null, "{controller}/{action}");
		}
    }
}
