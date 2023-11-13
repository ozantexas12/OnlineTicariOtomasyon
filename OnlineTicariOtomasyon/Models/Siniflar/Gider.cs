using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderID { get; set; }
        public string Aciklama {  get; set; }
        public decimal GiderFiyatı { get; set; }
        public DateTime Tarih {  get; set; }

    }
}