using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PresentationLayerAdmi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //indica de cual ventana inicia la aplicación
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } //sentencia para iniciar desde el home
                defaults: new { controller = "Access", action = "Login", id = UrlParameter.Optional } //sentencia para iniciar desde el login
            );
        }
    }
}
