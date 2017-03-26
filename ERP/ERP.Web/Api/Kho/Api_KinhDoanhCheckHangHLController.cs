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
    public class Api_KinhDoanhCheckHangHLController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        public List<tonkhohanghoa> checkhanghl()
        {
            var data = (from t1 in db.HHs
                        join t2 in db.HH_TON_KHO on t1.MA_HANG equals t2.MA_HANG
                        select new {t1.MA_HANG, t1.MA_NHOM_HANG, t1.DON_VI_TINH, t2.MA_KHO, t2.SL_TON}
                        ).ToList();
          List<tonkhohanghoa>  result = data.ToList().Select(x => new tonkhohanghoa()
            {
                mahang = x.MA_HANG,
                manhomhang = x.MA_NHOM_HANG,
                donvitinh = x.DON_VI_TINH,
                makho = x.MA_KHO,
                soluongton = x.SL_TON.ToString()
            }).ToList();
            return result;
        }
    }
}
