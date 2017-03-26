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
                        join t2 in db.HH_TON_KHO on t1.MA_HANG equals t2.MA_HANG
                        join t3 in db.DM_KHO on t2.MA_KHO equals t3.MA_KHO
                        join t4 in db.HH_TONKHO_HANG on t1.MA_HANG equals t4.MA_HANG
                        select new { t1.MA_HANG, t1.MA_NHOM_HANG, t1.DON_VI_TINH, t3.TEN_KHO, t2.SL_TON, t4.SL }
                        ).ToList();
            List<tonkhohanghoa> result = data.ToList().Select(x => new tonkhohanghoa()
            {
                mahang = x.MA_HANG,
                manhomhang = x.MA_NHOM_HANG,
                donvitinh = x.DON_VI_TINH,
                makho = x.TEN_KHO,
                soluongton = x.SL_TON.ToString(),
                tonkhohang = x.SL.ToString()
            }).ToList();
            return result;
        }

    }
}
