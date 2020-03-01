using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVC.Context;
using MVC.Models;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected async void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SampleContext sww = new SampleContext();
            sww.Contacts.Add(new Contact()
            {
                Surname = "Filippov",
                BDay = new DateTime(2000, 02, 23),
                Firstname = "Vitali",
                Middlename = "Leonidovich",
                Phone = "293333333"
            });
            await sww.SaveChangesAsync();
            var d = sww.Contacts.Where(n=>n.Phone.Equals("293333333")).ToList();
        }
    }
}
