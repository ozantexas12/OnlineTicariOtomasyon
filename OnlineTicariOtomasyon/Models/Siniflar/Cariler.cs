using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CarilerID { get; set; }

        [Display(Name = "Cariler Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Yazabilirsiniz")]
        public string CarilerAdi { get; set; }
        [Display(Name = "Cariler Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı Boş Geçmeyiniz!")]
        public string CarilerSoyadi { get; set; }
        [Display(Name = "Cariler Şehir")]
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CarilerSehir {  get; set; }
        [Display(Name = "Cariler Mail")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CarilerMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CarilerSifre { get; set; }

        public bool CarilerDurum {  get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}