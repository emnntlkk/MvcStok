using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler

        MvcDbStokEntities DbModel = new MvcDbStokEntities();
        public ActionResult UrunListele()
        {
            var urunliste = DbModel.TBLURUNLER.ToList();


            return View(urunliste);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in DbModel.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }
                                           ).ToList();
            ViewBag.urunlist = degerler;
            return View();
            
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER urun)
        {
            var ktg=DbModel.KATEGORILER.Where(m=>m.KATEGORIID==urun.KATEGORILER.KATEGORIID).FirstOrDefault();
            urun.KATEGORILER = ktg;
            DbModel.TBLURUNLER.Add(urun);
            DbModel.SaveChanges();
            return RedirectToAction("UrunListele");

        }

        public ActionResult UrunSil(int id) 
        {
            var urun = DbModel.TBLURUNLER.Find(id);
            DbModel.TBLURUNLER.Remove(urun);
            DbModel.SaveChanges();
            return RedirectToAction("UrunListele");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = DbModel.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in DbModel.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }
                                          ).ToList();
            ViewBag.urunlist = degerler;

            return View(urun);
        }



        
        public ActionResult UrunGuncelle(TBLURUNLER p)
        {
            var urun = DbModel.TBLURUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.MARKA = p.MARKA;
            var ktg = DbModel.KATEGORILER.Where(m => m.KATEGORIID == p.KATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            DbModel.SaveChanges();
            return RedirectToAction("UrunListele");

        }


    }
}