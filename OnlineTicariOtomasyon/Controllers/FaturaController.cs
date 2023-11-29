using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c=new Context();
        public ActionResult Index()
        {
            var liste=c.Faturas.ToList();
            return View(liste);
        }
    }
}