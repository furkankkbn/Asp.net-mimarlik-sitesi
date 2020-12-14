using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MBY.Models
{
    [Table("Admin")]
    public class Admin
    {
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
         public string KullaniciAdi { get; set; }
         public string Sifre { get; set; }
         public string AdSoyad { get; set; }
         public string TelefonNumarası { get; set; }
         public string Adres { get; set; }
    }
}