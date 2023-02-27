using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        MvcDbStokEntities DbModel = new MvcDbStokEntities();
        public ActionResult MusteriListesi(string p)
        {
            var degerler = from d in DbModel.TBLMUSTERILER select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
        }


        [HttpGet]
        public ActionResult YeniMusteri()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER musteri)
        {
            if(!ModelState.IsValid)
            { 
                return View("YeniMusteri"); 
            }
            DbModel.TBLMUSTERILER.Add(musteri);
            DbModel.SaveChanges();
            return View();
        }

        public ActionResult MusteriSil(int id)
        {
            var musteri = DbModel.TBLMUSTERILER.Find(id);
            DbModel.TBLMUSTERILER.Remove(musteri);
            DbModel.SaveChanges();
            return RedirectToAction("MusteriListesi");
        }

        public ActionResult MusteriGetir(int ?id= null)
        {
            var musteri = DbModel.TBLMUSTERILER.Find(id);
            return View(musteri);
        
        }

        public ActionResult MusteriGuncelle(TBLMUSTERILER prmt)
        {
            var musteri = DbModel.TBLMUSTERILER.Find(prmt.MUSTERIID);
            musteri.MUSTERIAD = prmt.MUSTERIAD;
            musteri.MUSTERISOYAD = prmt.MUSTERISOYAD;
            DbModel.SaveChanges();
            return RedirectToAction("MusteriListesi");
        }
            
    }
}