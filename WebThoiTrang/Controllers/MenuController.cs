using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.EF;
namespace WebThoiTrang.Controllers
{
    public class MenuController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        //
        // GET: /Menu/
        public ActionResult MenuTop()
        {
            var items = dbConnect.Categories.OrderBy(x => x.Position).ToList();
            return PartialView("_MenuTop",items);
        }

        public ActionResult MenuProductCategory()
        {
            var items = dbConnect.ProductCategories.ToList();
            return PartialView("_MenuProductCategory", items);
        }
        public ActionResult MenuLeft(int? id)
        {
            if(id != null)
            {
                ViewBag.CateId = id;
            }
            var items = dbConnect.ProductCategories.ToList();
            return PartialView("_MenuLeft", items);
        }

        public ActionResult MenuArrivals()
        {
            var items = dbConnect.ProductCategories.ToList();
            return PartialView("_MenuArrivals", items);
        }
	}
}