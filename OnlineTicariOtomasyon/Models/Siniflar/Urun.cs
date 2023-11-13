using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        public string UrunAdı { get; set;}
        public string UrunMarka {  get; set;}
        public short UrunStok {  get; set;}
        public decimal AlisFiyat { get; set;}
        public decimal SatisFiyat { get; set;}
        public bool UrunDurum {  get; set;}
        public string UrunGorsel {  get; set;}
        public Kategori Kategori { get; set;}
    }
}