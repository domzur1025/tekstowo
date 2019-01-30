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
                defaults: new {controller="Song", action="Lyrics",songId=UrlParameter.Optional}
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
                name: "Registration",
                url: "Registration",
                defaults: new { Controller = "User", action = "Registration" }
                );

            routes.MapRoute(
                name:"Login",
                url:"Login",
                defaults: new {Controller="User", Action="Login"}
                );

            routes.MapRoute(
                name: "Logout",
                url: "Logout",
                defaults: new { Controller = "User", Action = "Logout" }
                );

            routes.MapRoute(
                name: "AdminPanel",
                url: "Admin",
                defaults: new { Controller = "Admin", Action = "Index" });

            routes.MapRoute(
                name: "AdminPanelSongsList",
                url: "Admin/SongsList",
                defaults: new { Controller = "Admin", Action = "SongList" });

            routes.MapRoute(
                name: "AdminPanelUsersList",
                url: "Admin/UsersList",
                defaults: new { Controller = "Admin", Action = "UsersList" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
