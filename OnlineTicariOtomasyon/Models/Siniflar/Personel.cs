using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        public string PersonelAdı {  get; set; }
        public string PersonelSoyadı { get; set;}
        public string PersonelGorsel {  get; set; }
        public SatisHareket SatisHareket { get; set; }  
        public Departman Departman { get; set; }

    }
}