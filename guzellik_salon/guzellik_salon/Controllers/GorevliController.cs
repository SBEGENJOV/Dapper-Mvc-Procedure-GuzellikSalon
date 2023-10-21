using Dapper;
using guzellik_salon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace guzellik_salon.Controllers
{
    public class GorevliController : Controller
    {
        // GET: Gorevli
        public ActionResult Index()
        {
            return View(DP.Listeleme<GorevliModel>("gList"));
        }

        public ActionResult EY(int id=0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param=new DynamicParameters();
                param.Add("gorevliNo", id);
                return View(DP.Listeleme<GorevliModel>("gListNo",param).FirstOrDefault<GorevliModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(GorevliModel model)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("gorevliNo", model.gorevliNo);
            param.Add("AdSoyad", model.AdSoyad);
            param.Add("Yas", model.Yas);
            param.Add("Telefon", model.Telefon);
            param.Add("mesaiDurum", model.mesaiDurum);
            param.Add("maas", model.maas);
            param.Add("prim", model.prim);
            param.Add("salonNo", model.salonNo);

            DP.ExecuteReturn("gEY", param);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id=0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("gorevliNo", id);
            DP.ExecuteReturn("gDelete", param);
            return RedirectToAction("Index");

        }
    }
}
