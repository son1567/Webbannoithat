using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.EF;
namespace WebThoiTrang.Controllers
{
    public class ReviewController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Review(int productId)
        {
            ViewBag.ProductId = productId;
            var item = new Review();
            if (User.Identity.IsAuthenticated)
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindByName(User.Identity.Name);
                if (user != null)
                {
                    item.Email = user.Email;
                    item.FullName = user.FullName;
                    item.UserName = user.UserName;
                }
                return PartialView(item);
            }
            return PartialView();
        }

        public ActionResult _Load_Review(int ProductId)
        {
            var item = dbConnect.Reviews.Where(x => x.ProductId == ProductId).Take(1).OrderByDescending(x=>x.Id).ToList();
            ViewBag.Count = item.Count;
            return PartialView(item);
        }

        [HttpPost]
        public ActionResult PostReview(Review req)
        {
            if (ModelState.IsValid)
            {
                req.createdDate = DateTime.Now;
                dbConnect.Reviews.Add(req);
                dbConnect.SaveChanges();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}