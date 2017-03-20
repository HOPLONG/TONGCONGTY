using ERP.Web.Models.BusinessModel;
using ERP.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Areas.HopLong.Controllers
{
   
    [AuthorizeBussiness]
    public class NguoiDungController : Controller
    {
        ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        // GET: HopLong/NguoiDungHL
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HT_NGUOI_DUNG hT_NGUOI_DUNG = db.HT_NGUOI_DUNG.Find(id);
            if (hT_NGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            return View(hT_NGUOI_DUNG);
        }

        public ActionResult Lichsu(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HT_NGUOI_DUNG hT_NGUOI_DUNG = db.HT_NGUOI_DUNG.Find(id);
            if (hT_NGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            return View(hT_NGUOI_DUNG);
        }
    }
}