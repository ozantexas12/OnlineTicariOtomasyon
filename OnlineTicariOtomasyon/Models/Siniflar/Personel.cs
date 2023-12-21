using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAdı { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyadı { get; set; }

        [Display(Name = "Personel Gorsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        [Display(Name = "Departman Id")]
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }

    }
}