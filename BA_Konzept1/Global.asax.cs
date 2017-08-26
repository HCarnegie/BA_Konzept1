using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BA_Konzept1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			System.Data.Entity.Database.SetInitializer<BA_Konzept.Domain.Concrete.EFDbContext>(new BA_Konzept.Domain.Concrete.EFInitializer());
        }
    }
}
