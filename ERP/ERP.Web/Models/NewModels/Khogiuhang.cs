﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.Models.NewModels
{
    public class Khogiuhang
    {
        public string MA_GIU_KHO { set; get; }
        public string SALES_GIU { set; get; }
        public string MA_KHACH_HANG { set; get; }
        public DateTime NGAY_GIU { set; get; }
        public string HO_VA_TEN { set; get; }
        public string TEN_CONG_TY { set; get; }
        public bool HUY_DON_GIU { set; get; }
        public bool DON_DANG_XUAT { set; get; }
        public bool DON_DA_HOAN_THANH { set; get; }
    }
}