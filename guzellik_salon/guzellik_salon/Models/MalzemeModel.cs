using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace guzellik_salon.Models
{
    public class MalzemeModel
    {
        public int malzemeNo { get; set; }
        public string Ad { get; set; }
        public int Tutar { get; set; }
        public decimal fayda { get; set; }
        public string aciklama { get; set;}
        public int hizmetNo { get; set;}
    }
}