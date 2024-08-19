﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebThoiTrang.Models;
namespace WebThoiTrang
{
    public class SettingHelper
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static string GetValue(string key)
        {
            var item = db.SystemSetting.SingleOrDefault(x=>x.SettingKey == key);
            if (item != null)
            {
                return item.SettingValue;
            }
            return "";
        }
    }
}