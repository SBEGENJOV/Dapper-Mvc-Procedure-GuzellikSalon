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
    public class HizmetlerController : Controller
    {
        // GET: Hizmetler
        public ActionResult Index()
        {
            return View(DP.Listeleme<HizmetModel>("hList"));
        }
        public ActionResult EY(int id=0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param= new DynamicParameters();
                param.Add("hizmetNo", id);
                return View(DP.Listeleme<HizmetModel>("hListNo",param).FirstOrDefault<HizmetModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(HizmetModel model)
        {
            DynamicParameters param= new DynamicParameters();
            param.Add("hizmetNo", model.hizmetNo);
            param.Add("Ad", model.Ad);
            param.Add("Amac", model.Amac);
            param.Add("tutar", model.tutar);
            param.Add("odemeDurum", model.odemeDurum);
            param.Add("gorevliNo", model.gorevliNo);

            DP.ExecuteReturn("hEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id=0)
        {
            DynamicParameters param= new DynamicParameters();
            param.Add("hizmetNo",id);
            DP.ExecuteReturn("hDelete", param);
            return RedirectToAction("Index");
        }
    }
}