﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;

namespace WebThoiTrang.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Contact
        public ActionResult Index(string id)
        {

            return View();
        }
    }
}