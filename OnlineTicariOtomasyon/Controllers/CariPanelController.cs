using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = User.Identity.Name;
            var degerler = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            ViewBag.m = mail;
            var mailid=c.Carilers.Where(x=>x.CarilerMail==mail).Select(y=>y.CarilerID).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.CarilerId == mailid).Count();
            ViewBag.toplamsatis=toplamsatis;
            var satisHareketleri = c.SatisHarekets;
            var ToplamTutar = (satisHareketleri != null && satisHareketleri.Any(x => x.CarilerId == mailid)) ? satisHareketleri.Where(x => x.CarilerId == mailid).Sum(y => y.ToplamTutar) : 0;
            ViewBag.ToplamTutar = ToplamTutar;
            var ToplamUrunSayisi = (satisHareketleri != null && satisHareketleri.Any(x => x.CarilerId == mailid)) ? satisHareketleri.Where(x => x.CarilerId == mailid).Sum(y => y.Adet) : 0;
            ViewBag.ToplamUrunSayisi = (ToplamUrunSayisi > 0) ? ToplamUrunSayisi : 0;
            var AdSoyad = c.Carilers.Where(x => x.CarilerMail == mail).Select(y => y.CarilerAdi + " " + y.CarilerSoyadi).FirstOrDefault();
            ViewBag.AdSoyad = AdSoyad;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            string mail = User.Identity.Name;
            var id = c.Carilers.Where(x => x.CarilerMail == mail.ToString()).Select(y => y.CarilerID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CarilerId == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            string mail = User.Identity.Name;
            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            string mail = User.Identity.Name;
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z => z.MesajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MesajDetay(int? id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CarilerMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CarilerMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            string mail = HttpContext.User.Identity.Name;
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();

        }
        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));
            }
            return View(k.ToList());
        }
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
        public PartialViewResult Partia1()
        {
            var mail = User.Identity.Name;
            var id=c.Carilers.Where(x=>x.CarilerMail==mail).Select(y=>y.CarilerID).FirstOrDefault();
            var caribul = c.Carilers.Find(id);
            return PartialView("Partia1",caribul);
        }
        public PartialViewResult Partial2() 
        {
            var veriler=c.Mesajlars.Where(x=>x.Gonderici=="admin").ToList(); 
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Cariler s)
        {
            var cr = c.Carilers.Find(s.CarilerID);
            cr.CarilerAdi = s.CarilerAdi;
            cr.CarilerSoyadi = s.CarilerSoyadi;
            cr.CarilerSifre = s.CarilerSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}