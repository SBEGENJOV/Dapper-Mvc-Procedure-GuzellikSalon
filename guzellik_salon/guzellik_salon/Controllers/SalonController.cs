using guzellik_salon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;


namespace guzellik_salon.Controllers
{
    public class SalonController : Controller
    {
        // GET: Salon
        public ActionResult Index()
        {
            return View(DP.Listeleme<SalonModel>("sList"));
        }

        public ActionResult EY(int id = 0)
        {
            if (id == 0) //ekleme sayfası yüklenir
            {
                return View();
            }
            else //id ye göre günceleme ekranı gelir.
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@salonNo", id);
                return View(DP.Listeleme<SalonModel>("sListNo", param).FirstOrDefault<SalonModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(SalonModel salon)//post kodları verileri buradan SQL e geri gönderiyoruz.
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("salonNo", salon.salonNo);
            param.Add("ad", salon.Ad);
            param.Add("kapiNo", salon.KapiNo);
            param.Add("yapilanİslem", salon.yapilanİslem);
            param.Add("islemsayisi", salon.islemsayisi);

            DP.ExecuteReturn("sEY", param);
           return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("salonNo", id);
            DP.ExecuteReturn("sDelete", param);
            return RedirectToAction("Index");
        }
    }
}