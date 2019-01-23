using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tekstowo.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AllSongs",
                url: "Songs",
                defaults: new { Controller = "Song", action = "List" }
            );

            routes.MapRoute(
                name: "ArtistSongs",
                url: "Songs/{ArtistId}",
                defaults: new { Controller = "Song", action = "List" }
            );

            routes.MapRoute(
                name:"SongLyrics",
                url:"Lyrics/{songId}",
                defaults: new {controller="Song", action="Lyrics"}
                );

            routes.MapRoute(
                name: "AddLyrics",
                url: "AddLyrics",
                defaults: new { Controller = "Song", action = "AddLyrics" }
            );

            routes.MapRoute(
                name: "Artists",
                url: "Artists/{page}",
                defaults: new { Controller = "Artist", action = "List" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
