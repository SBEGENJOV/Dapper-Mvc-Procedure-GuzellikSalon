using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace guzellik_salon.Models
{
    public class HizmetModel
    {
        public int hizmetNo { get; set; }
        public string Ad { get; set; }
        public string Amac { get; set; }
        public decimal tutar { get; set; }
        public bool odemeDurum { get; set; }
        public int gorevliNo { get; set; }
    }
}