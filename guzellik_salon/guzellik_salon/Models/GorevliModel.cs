using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace guzellik_salon.Models
{
    public class GorevliModel
    {
        public int gorevliNo { get; set; }
        public string AdSoyad { get; set; }
        public int Yas { get; set; }
        public string Telefon { get; set; }
        public bool mesaiDurum { get; set; }
        public decimal maas { get; set; }
        public decimal prim { get; set; }
        public int salonNo { get; set; }

    }
}