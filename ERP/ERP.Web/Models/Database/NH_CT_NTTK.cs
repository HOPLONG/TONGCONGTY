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
    
    public partial class NH_CT_NTTK
    {
        public int ID { get; set; }
        public string SO_CHUNG_TU { get; set; }
        public string DIEN_GIAI { get; set; }
        public string LOAI_TIEN { get; set; }
        public decimal TY_GIA { get; set; }
        public string TK_NO { get; set; }
        public string TK_CO { get; set; }
        public decimal SO_TIEN { get; set; }
        public decimal QUY_DOI { get; set; }
        public string MA_DOI_TUONG { get; set; }
        public string DON_VI { get; set; }
    
        public virtual CCTC_PHONG_BAN CCTC_PHONG_BAN { get; set; }
        public virtual DM_DOI_TUONG DM_DOI_TUONG { get; set; }
        public virtual DM_TAI_KHOAN_HACH_TOAN DM_TAI_KHOAN_HACH_TOAN { get; set; }
        public virtual DM_TAI_KHOAN_HACH_TOAN DM_TAI_KHOAN_HACH_TOAN1 { get; set; }
        public virtual NH_NTTK NH_NTTK { get; set; }
    }
}
