using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var dgr1 = c.Carilers.Count().ToString();
            ViewBag.d1 = dgr1;
            var dgr2 = c.Uruns.Count().ToString();
            ViewBag.d2 = dgr2;
            var dgr3 = c.Personels.Count().ToString();
            ViewBag.d3 = dgr3;
            var dgr4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = dgr4;
            var dgr5 = c.Uruns.Sum(x => x.UrunStok).ToString();
            ViewBag.d5 = dgr5;
            var dgr6 = (from x in c.Uruns select x.UrunMarka).Distinct().Count().ToString();
            ViewBag.d6 = dgr6;
            var dgr7 = c.Uruns.Count(x => x.UrunStok <= 20).ToString();
            ViewBag.d7 = dgr7;
            var dgr8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAdı).FirstOrDefault();
            ViewBag.d8 = dgr8;
            var dgr9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAdı).FirstOrDefault();
            ViewBag.d9 = dgr9;
            var dgr10 = c.Uruns.GroupBy(x => x.UrunMarka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d10 = dgr10;
            var dgr11 = c.Uruns.Count(x => x.UrunAdı == "Buzdolabı").ToString();
            ViewBag.d11 = dgr11;
            var dgr12 = c.Uruns.Count(x => x.UrunAdı == "Laptop").ToString();
            ViewBag.d12 = dgr12;
            var dgr13 = c.Uruns.Where(u => u.UrunId == (c.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAdı).FirstOrDefault();
            ViewBag.d13 = dgr13;
            var dgr14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = dgr14;

            DateTime bugun = DateTime.Today;
            var dgr15 = c.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = dgr15;
            var dgr16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
            ViewBag.d16 = dgr16;
            return View();
        }
    }
}