using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAdı,
                                               Value = x.UrunId.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CarilerAdı + " " + x.CarilerSoyadı,
                                               Value = x.CarilerID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAdı + " " + x.PersonelSoyadı,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAdı,
                                               Value = x.UrunId.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CarilerAdi + " " + x.CarilerSoyadı,
                                               Value = x.CarilerID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAdı + " " + x.PersonelSoyadi,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var deger = c.SatisHarekets.Find(p.SatisID);
            deger.CarilerId = p.CarilerId;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.PersonelId = p.PersonelId;
            deger.Tarih = p.Tarih;
            deger.ToplamTutar = p.ToplamTutar;
            deger.UrunId = p.UrunId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        }
    }
}