using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.EF;
namespace WebThoiTrang.Areas.Admin.Controllers
{
    [Authorize(Roles = "Quản trị,Nhân viên")]
    public class PostController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        //
        // GET: /Admin/Post/
        public ActionResult Index()
        {
            var items = dbConnect.Post.OrderByDescending(x => x.Id).ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Posts model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.CategoryID = 1;
                model.Alias = WebThoiTrang.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Post.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = dbConnect.Post.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts model)
        {
            if (ModelState.IsValid)
            {
                dbConnect.Post.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebThoiTrang.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Entry(model).Property(x => x.Title).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Image).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Description).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Detail).IsModified = true;
                dbConnect.Entry(model).Property(x => x.IsActive).IsModified = true;
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
            var item = dbConnect.Post.Find(id);
            if (item != null)
            {
                dbConnect.Post.Remove(item);
                dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = dbConnect.Post.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                dbConnect.Entry(item).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                return Json(new { success = true, isactive = item.IsActive });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = dbConnect.Post.Find(Convert.ToInt32(item));
                        dbConnect.Post.Remove(obj);
                        dbConnect.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
	}
}