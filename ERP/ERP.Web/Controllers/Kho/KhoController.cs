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
    public class KhoController : Controller
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: HopLong/Kho
        public ActionResult Index()
        {
            var dM_KHO = db.DM_KHO.Include(d => d.CCTC_CONG_TY).Include(d => d.DM_KHO2);
            return View(dM_KHO.ToList());
        }

    }
}
