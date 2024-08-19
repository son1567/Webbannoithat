using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.EF;

namespace WebThoiTrang.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Wishlist
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostWishlist(int ProductId)
        {
            if (Request.IsAuthenticated == false)
            {
                return Json(new { Success = false, Message="Vui lòng đăng nhập." });
            }
            var item = new WishList();
            item.ProductId = ProductId;
            item.UserName = User.Identity.Name;
            item.createdDate = DateTime.Now;
            dbConnect.WishLists.Add(item);
            dbConnect.SaveChanges();
            return Json(new { Success = true });
        }
        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}