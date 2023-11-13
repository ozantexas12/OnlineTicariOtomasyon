﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID {  get; set; }
        public string DepartmanAdı { get; set; }
        public ICollection<Personel>Personels { get; set; }
    }
}