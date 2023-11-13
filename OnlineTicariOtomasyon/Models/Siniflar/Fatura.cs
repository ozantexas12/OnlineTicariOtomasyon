﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaID { get; set; }
        public string FaturaSeriNo {  get; set; }
        public string FaturaSıraNo {  get; set; }
        public DateTime FaturaTarihi { get; set; }
        public string VergiDairesi { get; set; }
        public DateTime Saat {  get; set; }
        public string TeslimEden { get; set; }
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }  

    }
}