using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.EF;

namespace WebThoiTrang.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: News
        public ActionResult Index(int? page)
        {
            var PageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<News> items = dbConnect.News.OrderByDescending(x => x.CreatedDate);
            var PageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(PageIndex, PageSize);
            ViewBag.PageSize = PageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Detail(int id)
        {
            var item = dbConnect.News.Find(id);
            return View(item);
        }
        public ActionResult Partial_News_Home()
        {
            var items = dbConnect.News.Take(3).ToList();
            return PartialView(items);
        }
    }
}