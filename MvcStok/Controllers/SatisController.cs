﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis

        MvcDbStokEntities DbModel = new MvcDbStokEntities();
        public ActionResult SatislarSayfasi()
        {
            return View();
        }


        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR prmt)
        {
            DbModel.TBLSATISLAR.Add(prmt);
            DbModel.SaveChanges();
            return View("SatislarSayfasi");
        }


    }
}