﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAdı {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyadı { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel {  get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

        public int Departmanid {  get; set; }
        public virtual Departman Departman { get; set; }

    }
}