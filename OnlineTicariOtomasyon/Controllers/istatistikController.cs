using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
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
            var bugunkuSatislar = c.SatisHarekets.Where(x => x.Tarih == bugun);

            // Bugünkü satışların sayısını kontrol et
            int satisAdeti = bugunkuSatislar.Count();
            ViewBag.d15 = satisAdeti.ToString();

            // Eğer bugün satış yapılmışsa ToplamTutar'ı topla, aksi halde 0 olarak ata
            decimal bugunkuToplamTutar = satisAdeti > 0 ? bugunkuSatislar.Sum(y => y.ToplamTutar) : 0;
            ViewBag.d16 = bugunkuToplamTutar.ToString();
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CarilerSehir into g
                        select new SinifGroup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAdı into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial4()
        {
            var sorgu4 = from x in c.Uruns
                         group x by x.UrunMarka into g
                         select new Marka
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu4.ToList());
        }
        public PartialViewResult Partial3()
        {
            var sorgu3 = from x in c.Kategoris
                         group x by x.KategoriAd into g
                         select new SinifGroup3
                         {
                             Kategori = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu3.ToList());
        }
    }
}