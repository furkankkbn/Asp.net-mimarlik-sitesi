using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MBY.Models
{
     [Table("Ekip")]
    public class Ekip
    {
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
         public string AdSoyad { get; set; }
         public string Unvan { get; set; }
         public string Aciklama { get; set; }
         public string Fotograf { get; set; }
         [DataType(DataType.Upload)]
         [Display(Name = "Upload File")]
         [Required(ErrorMessage = "Please choose file to upload.")]
         public HttpPostedFileBase[] files { get; set; } 
 
    }
}