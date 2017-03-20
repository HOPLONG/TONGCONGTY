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

    public class HangHoaController : Controller
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: HopLong/HangHoaHL
        public ActionResult Index()
        {
            var dM_HANG_HOA = db.HHs.Include(d => d.HH_NHOM_VTHH).Include(d => d.DM_TAI_KHOAN_HACH_TOAN).Include(d => d.DM_TAI_KHOAN_HACH_TOAN1).Include(d => d.DM_TAI_KHOAN_HACH_TOAN2);
            return View(dM_HANG_HOA.ToList());
        }

    }
}
