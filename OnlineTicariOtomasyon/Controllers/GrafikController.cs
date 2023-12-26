using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif1> Urunlistesi()
        {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
            {
                urunad = "Blgisayar",
                stoksayisi = 120
            });
            snf.Add(new sinif1()
            {
                urunad = "Beyaz Eşya",
                stoksayisi = 150
            });
            snf.Add(new sinif1()
            {
                urunad = "Küçük Ev Aletleri",
                stoksayisi = 180
            });
            snf.Add(new sinif1()
            {
                urunad = "Mobil Cihazlar",
                stoksayisi = 90
            });
            snf.Add(new sinif1()
            {
                urunad = "Mobilya",
                stoksayisi = 70
            });
            return snf;

        }

        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif2> UrunListesi2()
        {
            List<sinif2> snf = new List<sinif2>();
            using (var c = new Context())
            {
                snf = c.Uruns.Select(x => new sinif2
                {
                       urn=x.UrunAdi,
                       stk=x.UrunStok
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index2() 
        { 
            return View(); 
        }
        public ActionResult Index3() 
        { 
            return View(); 
        }
    }
}