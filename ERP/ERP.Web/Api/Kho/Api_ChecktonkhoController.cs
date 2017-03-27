using ERP.Web.Models.Database;
using ERP.Web.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.Web.Api.Kho
{
    public class Api_ChecktonkhoController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        // GET: api/Checktonkho
        public List<tonkhohanghoa> Get()
        {
            var data = (from t1 in db.HHs
                        join t2 in db.KHO_TON_HOPLONG on t1.MA_HANG equals t2.MA_HANG
                        join t3 in db.KHO_TON_TAHCM on t1.MA_HANG equals t3.MA_HANG
                        join t4 in db.KHO_TON_TADN on t1.MA_HANG equals t4.MA_HANG
                        join t5 in db.HH_TONKHO_HANG on t1.MA_HANG equals t5.MA_HANG
                        //join t6 in db.HH_TON_KHO_GIU on t1.MA_HANG equals t6.MA_HANG
                        //where t6.MA_KHO_GIU == "IVHOPLONG"
                        select new { t1.MA_HANG, t1.DON_VI_TINH, t1.MA_NHOM_HANG, t2.TON_KHO_HL, t3.TON_KHO_HCM, t4.TON_KHO_DN, t5.SL_TON}
                         ).ToList();
            var query = data.ToList().Select(x => new tonkhohanghoa
            {
                mahang = x.MA_HANG,
                manhomhang = x.MA_NHOM_HANG,
                donvitinh = x.DON_VI_TINH,
                tonkhohoplong = x.TON_KHO_HL.ToString(),
                tonkhoHCM = x.TON_KHO_DN.ToString(),
                tonkhoDN = x.TON_KHO_DN.ToString(),
                tonkhohang = x.SL_TON.ToString(),
               // tonkhogiu = x.SL.ToString()
            }).ToList();
            return query;
        }
    

    }
}
