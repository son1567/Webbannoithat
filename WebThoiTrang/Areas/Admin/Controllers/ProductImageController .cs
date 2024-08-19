using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.EF;
using PagedList;
namespace WebThoiTrang.Areas.Admin.Controllers
{
    [Authorize(Roles = "Quản trị,Nhân viên")]
    public class ProductImageController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        //
        // GET: /Admin/Product/
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var items = dbConnect.ProductImages.Where(x => x.ProductId == id).ToList();
            return View(items);
        }
        
        [HttpPost]
        public ActionResult Add(int productId,string url)
        {
            dbConnect.ProductImages.Add(new ProductImage
            {
                ProductId = productId,
                Image = url,
                IsDefault = false
            });
            dbConnect.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbConnect.ProductImages.Find(id);
            dbConnect.ProductImages.Remove(item);
            dbConnect.SaveChanges();
            return Json(new {success=true});
        }
    }
}