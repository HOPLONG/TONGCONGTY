using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.Web.Models.Database;
using System.IO;

namespace ERP.Web.Controllers
{
    public class KhachHangController : Controller
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: KhachHang
        public ActionResult Index()
        {
            var kHs = db.KHs.Include(k => k.CCTC_CONG_TY);
            return View(kHs.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Index(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Verify that the user selected a file
                    if (file != null && file.ContentLength > 0)
                    {
                        // extract only the fielname
                        var fileName = Path.GetFileName(file.FileName);
                        // TODO: need to define destination
                        var path = Path.Combine(Server.MapPath("~/Content/Images/KhachHang"), fileName);
                        file.SaveAs(path);
                    }
                }
            }
        }

    }
}
