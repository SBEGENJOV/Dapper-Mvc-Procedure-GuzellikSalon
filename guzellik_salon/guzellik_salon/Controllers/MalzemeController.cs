using Dapper;
using guzellik_salon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace guzellik_salon.Controllers
{
    public class MalzemeController : Controller
    {
        // GET: Malzeme
        public ActionResult Index()
        {
            return View(DP.Listeleme<MalzemeModel>("mList"));
        }

        public ActionResult EY(int id=0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("malzemeNo",id);
                return View(DP.Listeleme<MalzemeModel>("mListNo", param).FirstOrDefault<MalzemeModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(MalzemeModel malzeme)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("malzemeNo", malzeme.malzemeNo);
            param.Add("Ad", malzeme.Ad);
            param.Add("Tutar", malzeme.Tutar);
            param.Add("fayda", malzeme.fayda);
            param.Add("aciklama", malzeme.aciklama); 
            param.Add("hizmetNo", malzeme.hizmetNo);

            DP.ExecuteReturn("mEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("malzemeNo", id);
            DP.ExecuteReturn("mDelete", param);
            return RedirectToAction("Index");
        }
    }
}