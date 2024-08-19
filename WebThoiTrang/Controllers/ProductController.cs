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
    public class ProductController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        //
        // GET: /Product/
        public ActionResult Index(int? id, int? page, string SearchText)
        {
            var PageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Product> items = dbConnect.Products.OrderByDescending(x => x.Id);
            if (id != null)
            {
                items = items.Where(x => x.ProductCategoryID == id).ToList();
                
            }
            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.Alias.Contains(SearchText) || x.Title.Contains(SearchText));
            }
            var PageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(PageIndex, PageSize);
            ViewBag.PageSize = PageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult ProductCategory(string alias, int id, int? page, string SearchText)
        {
            var PageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Product> items = dbConnect.Products.OrderByDescending(x => x.Id);
            if (id >0)
            {
                items = items.Where(x => x.ProductCategoryID == id).ToList();
            }
            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.Alias.Contains(SearchText) || x.Title.Contains(SearchText));
            }
            var cate = dbConnect.ProductCategories.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateId = id;
            var PageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(PageIndex, PageSize);
            ViewBag.PageSize = PageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Partial_Items_ByCateId()
        {
            var items = dbConnect.Products.Where(x => x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }

        public ActionResult Partial_ProductSales()
        {
            var items = dbConnect.Products.Where(x => x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
        public ActionResult Detail(string alias,int id)
        {
            var item = dbConnect.Products.Find(id);
            if (item != null)
            {
                dbConnect.Products.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                dbConnect.Entry(item).Property(x => x.ViewCount).IsModified = true;
                dbConnect.SaveChanges();
            }
            var countReview = dbConnect.Reviews.Where(x => x.ProductId == id).Count();
            ViewBag.CountReview = countReview;
            return View(item);
        }
    }
}