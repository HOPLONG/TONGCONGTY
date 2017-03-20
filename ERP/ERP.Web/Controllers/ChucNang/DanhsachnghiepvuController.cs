using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.Web.Models.Database;
using ERP.Web.Models.BusinessModel;

namespace ERP.Web.Areas.HopLong.Controllers
{
    [AuthorizeBussiness]
    public class DanhsachnghiepvuController : Controller
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        public ActionResult Index()
        {
            //var dsnghiepvu = db.CN_NGHIEP_VU.Include(c => c.CCTC_CONG_TY);
            //return View(dsnghiepvu.ToList());
            return View();
        }

        public ActionResult Capnhat_Nghiepvu()
        {
            ReflectionController rc = new ReflectionController();
            List<Type> danhsach_loainghiepvu = rc.GetControllers("ERP.Web.Areas.HopLong.Controllers");
            List<String> danhsach_nghiepvucu = db.CN_NGHIEP_VU.Select(c => c.ID).ToList();
            List<String> danhsach_chitietnghiepvucu = db.CN_CHI_TIET_NGHIEP_VU.Select(p => p.TEN_CHI_TIET).ToList();
            foreach (var c in danhsach_loainghiepvu)
            {
                if (!danhsach_nghiepvucu.Contains(c.Name))
                {
                    CN_NGHIEP_VU c_info = new CN_NGHIEP_VU()
                    {
                        ID = c.Name,
                        TEN_NGHIEP_VU = c.Name,
                        TRUC_THUOC = Session["MA_CONG_TY"].ToString()
                    };
                    db.CN_NGHIEP_VU.Add(c_info);
                }
                List<String> danhsach_chitietnghiepvu = rc.GetActions(c);
                foreach (var p in danhsach_chitietnghiepvu)
                {
                    if (!danhsach_chitietnghiepvucu.Contains(c.Name + "-" + p))
                    {
                        CN_CHI_TIET_NGHIEP_VU permission = new CN_CHI_TIET_NGHIEP_VU()
                        {
                            TEN_CHI_TIET = c.Name + "-" + p,
                            ID_NGHIEP_VU = c.Name,
                            MO_TA = c.Name + "-" + p

                        };
                        db.CN_CHI_TIET_NGHIEP_VU.Add(permission);
                    }
                }
            }
            db.SaveChanges();
            TempData["err"] = "<div class='alert alert-info' role='alert'><span class='glyphicon glyphicon-exclamation-sign' aria-hidden='true'></span><span class='sr-only'></span>Cập nhật thành công </div> ";
            return RedirectToAction("Index");

        }

   
    }
}
