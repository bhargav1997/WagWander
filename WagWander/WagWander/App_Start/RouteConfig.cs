﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WagWander
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AddReview",
                url: "Review/Add/{locationId}",
                defaults: new { controller = "Review", action = "Add" }
            );

            routes.MapRoute(
            name: "ViewReviews",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Location", action = "LocationWithReviews" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
