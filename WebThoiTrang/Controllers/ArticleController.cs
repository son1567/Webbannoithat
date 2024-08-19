using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;

namespace WebThoiTrang.Controllers
{
    public class ArticleController : Controller
    {
        private ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Article
        public ActionResult Index(string alias)
        {
            var item = dbConnect.Post.FirstOrDefault(x => x.Alias == alias);
            return View(item);
        }

        protected override void Dispose(bool disposing)
        {
           
            base.Dispose(disposing);
        }
    }
}