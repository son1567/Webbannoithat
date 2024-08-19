using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.EF;

namespace WebThoiTrang.Areas.Admin.Controllers
{
    [Authorize(Roles = "Quản trị")]
    public class CategoryController : Controller
    {

        ApplicationDbContext dbConnect = new ApplicationDbContext();
        //
        // GET: /Admin/Category/
        public ActionResult Index()
        {
            var items = dbConnect.Categories.ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebThoiTrang.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Categories.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = dbConnect.Categories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                dbConnect.Categories.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebThoiTrang.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Entry(model).Property(x => x.Title).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Description).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Link).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Position).IsModified = true;
                dbConnect.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                dbConnect.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                dbConnect.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Alias).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Title).IsModified = true;
                dbConnect.Entry(model).Property(x => x.ModifiedBy).IsModified = true;
                dbConnect.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbConnect.Categories.Find(id);
            if (item != null)
            {
                var DelItem = dbConnect.Categories.Attach(item);
                dbConnect.Categories.Remove(item);
                dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}