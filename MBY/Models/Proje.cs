using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace MBY.Models
{
    public class Proje
    {
      [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      public string Name { get; set; }
      public string Location { get; set; }
      public string Year { get; set; }
      public string Type { get; set; }
      public string Rooms { get; set; }
      public string Area { get; set; }
      public string Path { get; set; }
 
      public HttpPostedFileBase[] files { get; set; }  
    }
}