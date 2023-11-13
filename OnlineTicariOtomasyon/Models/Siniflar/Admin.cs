using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID {  get; set; }
        public string KullanıcıAdi { get; set; }
        public string Sifre {  get; set; }
        public string Yetki {  get; set; }
    }
}