using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.EF;

namespace WebThoiTrang.Areas.Admin.Controllers
{
    public class SettingSystemController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/SettingSystem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Partial_Setting()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddSetting(SettingSystemViewModel req)
        {
            SystemSetting set = null;
            var checkTitle = dbConnect.SystemSetting.FirstOrDefault(x => x.SettingKey.Contains("SettingTitle"));
            if (checkTitle==null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingTitle";
                set.SettingValue = req.SettingTitle;
                dbConnect.SystemSetting.Add(set);
            }
            else
            {
                checkTitle.SettingValue = req.SettingTitle;
                dbConnect.Entry(checkTitle).State = System.Data.Entity.EntityState.Modified;
            }
            //Logo
            var checkLogo = dbConnect.SystemSetting.FirstOrDefault(x => x.SettingKey.Contains("SettingLogo"));
            if (checkLogo == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingLogo";
                set.SettingValue = req.SettingLogo;
                dbConnect.SystemSetting.Add(set);
            }
            else
            {
                checkLogo.SettingValue = req.SettingLogo;
                dbConnect.Entry(checkLogo).State = System.Data.Entity.EntityState.Modified;
            }
            //Email
            var email = dbConnect.SystemSetting.FirstOrDefault(x => x.SettingKey.Contains("SettingEmail"));
            if (email == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingEmail";
                set.SettingValue = req.SettingEmail;
                dbConnect.SystemSetting.Add(set);
            }
            else
            {
                email.SettingValue = req.SettingEmail;
                dbConnect.Entry(email).State = System.Data.Entity.EntityState.Modified;
            }
            //Hotline
            var Hotline = dbConnect.SystemSetting.FirstOrDefault(x => x.SettingKey.Contains("SettingHotline"));
            if (Hotline == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingHotline";
                set.SettingValue = req.SettingHotline;
                dbConnect.SystemSetting.Add(set);
            }
            else
            {
                Hotline.SettingValue = req.SettingHotline;
                dbConnect.Entry(Hotline).State = System.Data.Entity.EntityState.Modified;
            }
            //TitleSeo
            var TitleSeo = dbConnect.SystemSetting.FirstOrDefault(x => x.SettingKey.Contains("SettingTitleSeo"));
            if (TitleSeo == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingTitleSeo";
                set.SettingValue = req.SettingTitleSeo;
                dbConnect.SystemSetting.Add(set);
            }
            else
            {
                TitleSeo.SettingValue = req.SettingTitleSeo;
                dbConnect.Entry(TitleSeo).State = System.Data.Entity.EntityState.Modified;
            }
            //DessSeo
            var DessSeo = dbConnect.SystemSetting.FirstOrDefault(x => x.SettingKey.Contains("SettingDesSeo"));
            if (DessSeo == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingDesSeo";
                set.SettingValue = req.SettingDesSeo;
                dbConnect.SystemSetting.Add(set);
            }
            else
            {
                DessSeo.SettingValue = req.SettingDesSeo;
                dbConnect.Entry(DessSeo).State = System.Data.Entity.EntityState.Modified;
            }
            //KeySeo
            var KeySeo = dbConnect.SystemSetting.FirstOrDefault(x => x.SettingKey.Contains("SettingKeySeo"));
            if (KeySeo == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingKeySeo";
                set.SettingValue = req.SettingKeySeo;
                dbConnect.SystemSetting.Add(set);
            }
            else
            {
                KeySeo.SettingValue = req.SettingKeySeo;
                dbConnect .Entry(KeySeo).State = System.Data.Entity.EntityState.Modified;
            }
            dbConnect.SaveChanges();
            return View("Partial_Setting");
        }
    }
}