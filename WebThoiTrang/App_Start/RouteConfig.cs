using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebThoiTrang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Contact", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebThoiTrang.Controllers" }
            );
            routes.MapRoute(
                name: "CategoryProduct",
                url: "danh-muc-san-pham/{alias}-{id}",
                defaults: new { controller = "Product", action = "ProductCategory", alias = UrlParameter.Optional },
                namespaces: new[] { "WebThoiTrang.Controllers" }
            );
            routes.MapRoute(
                name: "Newlists",
                url: "tin-tuc",
                defaults: new { controller = "News", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebThoiTrang.Controllers" }
            );
            routes.MapRoute(
               name: "Detail News",
               url: "{alias}-n{id}",
               defaults: new { controller = "News", action = "Detail", alias = UrlParameter.Optional },
               namespaces: new[] { "WebThoiTrang.Controllers" }
           );
            routes.MapRoute(
                name: "DetailProduct",
                url: "chi-tiet/{alias}-p{id}",
                defaults: new { controller = "Product", action = "Detail", alias = UrlParameter.Optional },
                namespaces: new[] { "WebThoiTrang.Controllers" }
            );
            routes.MapRoute(
                name: "Product",
                url: "san-pham",
                defaults: new { controller = "Product", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebThoiTrang.Controllers" }
            );
            routes.MapRoute(
                name: "BaiViet",
                url: "post/{alias}",
                defaults: new { controller = "Article", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebThoiTrang.Controllers" }
            );
            routes.MapRoute(
                name: "TrangChu",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebThoiTrang.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebThoiTrang.Controllers" }
            );
            
            //routes.MapRoute(
            //    name: "ShoppingCart",
            //    url: "gio-hang",
            //    defaults: new { controller = "ShoppingCart", action = "Index", alias = UrlParameter.Optional },
            //    namespaces: new[] { "WebThoiTrang.Controllers" }
            //);
        }
    }
}
