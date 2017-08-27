using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using BAKonzept1;

namespace BA_Konzept3
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
	        AreaRegistration.RegisterAllAreas();
	        GlobalConfiguration.Configure(WebApiConfig.Register);
	        RouteConfig.RegisterRoutes(RouteTable.Routes);   
			System.Data.Entity.Database.SetInitializer<BA_Konzept.Domain.Concrete.EFDbContext>(new BA_Konzept.Domain.Concrete.EFInitializer());
        }
    }
}
