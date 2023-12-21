using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.CarilerDurum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.CarilerDurum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.CarilerDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir",cari);
        }
        public ActionResult CariGuncelle(Cariler p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Carilers.Find(p.CarilerID);
            cari.CarilerAdı = p.CarilerAdı;
            cari.CarilerSoyadı = p.CarilerSoyadı;
            cari.CarilerSehir = p.CarilerSehir;
            cari.CarilerMail = p.CarilerMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.CarilerId == id).ToList();
            var cr = c.Carilers.Where(x => x.CarilerID == id).Select(y => y.CarilerAdı + " " + y.CarilerSoyadı).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}