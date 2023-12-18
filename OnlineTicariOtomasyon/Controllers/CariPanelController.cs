using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CarilerMail"];
            var degerler=c.Carilers.FirstOrDefault(x=>x.CarilerMail == mail);
            ViewBag.m = mail;  
            return View();
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CarilerMail"];
            var id=c.Carilers.Where(X=>X.CarilerMail == mail.ToString()).Select(y=>y.CarilerID).FirstOrDefault();
            var degerler=c.SatisHarekets.Where(x=>x.CarilerId==id).ToList();
            return View(degerler);
        }
    }
}