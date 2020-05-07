using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "M-1",
               url: "V2",
               defaults: new { controller = "MResearch", action = "M02" }
            );

            routes.MapRoute(
               name: "M-2",
               url: "V3",
               defaults: new { controller = "MResearch", action = "M03" }
            );

            routes.MapRoute(
                name: "M-3",
                url: "{controller}",
                defaults: new { controller = "MResearch", action = "M01" }
            );

            routes.MapRoute(
              name: "M-4",
              url: "V2/{controller}/{action}/{id}",
              defaults: new { controller = "MResearch", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "M-5",
               url: "V3/{controller}/{id}",
               defaults: new { controller = "MResearch", action = "M03", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "M-6",
               url: "V3/{controller}/{id}/{action}",
               defaults: new { controller = "MResearch", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "M-7",
               url: "{controller}/{action}/{id}",
               defaults: new { id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "M",
                url: "",    
                defaults: new { controller = "MResearch", action = "M01", id = UrlParameter.Optional }
            );
        }
    }
}
