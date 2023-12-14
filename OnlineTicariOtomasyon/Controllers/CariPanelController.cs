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
    }
}