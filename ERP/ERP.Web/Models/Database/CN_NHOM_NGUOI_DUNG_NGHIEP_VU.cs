//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Web.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class CN_NHOM_NGUOI_DUNG_NGHIEP_VU
    {
        public string USERNAME { get; set; }
        public string ID_NHOM_NGHIEP_VU { get; set; }
        public Nullable<bool> TRANG_THAI { get; set; }
    
        public virtual CN_NHOM_NGHIEP_VU CN_NHOM_NGHIEP_VU { get; set; }
        public virtual HT_NGUOI_DUNG HT_NGUOI_DUNG { get; set; }
    }
}
