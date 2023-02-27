using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MvcDbStokEntities DbModel = new MvcDbStokEntities();

        
        public ActionResult KategoriListesi(int sayfa=1)
        {
            //var kategoriListe = DbModel.KATEGORILER.ToList();
            var kategoriListe = DbModel.KATEGORILER.ToList().ToPagedList(sayfa,4);
            return View(kategoriListe);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            
            return View();
        }




        [HttpPost]
        public ActionResult YeniKategori(KATEGORILER ktgr)
        {
            if(!ModelState.IsValid)
            { return View("YeniKategori"); }
            DbModel.KATEGORILER.Add(ktgr);
            DbModel.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult KategoriSil(int id)
        {
            var ktgr = DbModel.KATEGORILER.Find(id);
            DbModel.KATEGORILER.Remove(ktgr);
            DbModel.SaveChanges();
            return RedirectToAction("KategoriListesi");
        }

        public ActionResult KategoriGetir(int? id=null)
        {
            var ktgr = DbModel.KATEGORILER.Find(id);
            return View(ktgr);
        }

        public ActionResult KategoriGuncelle(KATEGORILER prmt)
        {
            var ktgr = DbModel.KATEGORILER.Find(prmt.KATEGORIID);
            ktgr.KATEGORIAD = prmt.KATEGORIAD;
            DbModel.SaveChanges();
            return RedirectToAction("KategoriListesi");
        }
    }
}