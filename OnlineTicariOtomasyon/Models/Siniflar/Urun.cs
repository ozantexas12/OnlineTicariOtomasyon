using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        [Display(Name = ";Ürün Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAdı { get; set; }
        [Display(Name = "Ürün Marka")]
        public string UrunMarka { get; set; }
        [Display(Name = "Ürün Stok")]
        public short UrunStok { get; set; }
        [Display(Name = "Alış Fiyatı")]
        public decimal AlisFiyat { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SatisFiyat { get; set; }

        [Display(Name = "Ürün Durum")]
        public bool UrunDurum { get; set; }

        [Display(Name = "Ürün Görsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        [Display(Name = "Kategori Id")]
        public int KategoriId {  get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}