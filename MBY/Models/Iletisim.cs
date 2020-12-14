using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBY.Models
{
    public class Iletisim
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Icerik { get; set; }
    }
}