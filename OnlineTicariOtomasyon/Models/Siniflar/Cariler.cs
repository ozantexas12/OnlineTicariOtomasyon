using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CarilerID { get; set; }
        public string CarilerAdı { get; set; }
        public string CarilerSoyadı { get; set; }
        public string CarilerSehir {  get; set; }
        public string CarilerMail { get; set; }
        public SatisHareket SatisHareket { get; set; }
    }
}