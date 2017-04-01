using ERP.Web.Areas.HopLong.Models;
using ERP.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.Web.Api.NganHang
{
    public class NGUOI_DUNG_FULLController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/NGUOI_DUNG_FULL/
        public List<NguoiDungPhongBan> GetListNhanvien()
        {
            var vData = (from t1 in db.CCTC_NHAN_VIEN
                         join t2 in db.HT_NGUOI_DUNG on t1.USERNAME equals t2.USERNAME
                         join t3 in db.CCTC_PHONG_BAN on t1.MA_PHONG_BAN equals t3.MA_PHONG_BAN

                         select new { t1.USERNAME, t1.GIOI_TINH, t1.NGAY_SINH, t1.CHUC_VU, t1.QUE_QUAN, t1.THANH_TICH_CONG_TAC, t1.TRINH_DO_HOC_VAN, t2.HO_VA_TEN, t2.EMAIL, t2.SDT, t2.AVATAR, t3.TEN_PHONG_BAN, t1.MA_PHONG_BAN });


            var result = vData.ToList().Select(x => new NguoiDungPhongBan()
            {
                HO_VA_TEN = x.HO_VA_TEN,
                EMAIL = x.EMAIL,
                CHUC_VU = x.CHUC_VU,
                SDT = x.SDT,
                GIOI_TINH = x.GIOI_TINH,
                NGAY_SINH = x.NGAY_SINH.ToString(),
                QUE_QUAN = x.QUE_QUAN,
                THANH_TICH_CONG_TAC = x.THANH_TICH_CONG_TAC,
                TRINH_DO_HOC_VAN = x.TRINH_DO_HOC_VAN,
                AVATAR = x.AVATAR,
                TEN_PHONG_BAN = x.TEN_PHONG_BAN,
                USERNAME = x.USERNAME,
                MA_PHONG_BAN = x.MA_PHONG_BAN
            }).ToList();
            return result;
        }
    }
}