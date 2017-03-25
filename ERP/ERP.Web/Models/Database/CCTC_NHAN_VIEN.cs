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
    
    public partial class CCTC_NHAN_VIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CCTC_NHAN_VIEN()
        {
            this.BH_BAO_GIA = new HashSet<BH_BAO_GIA>();
            this.BH_DE_NGHI_GIU_HANG = new HashSet<BH_DE_NGHI_GIU_HANG>();
            this.CCTC_BANG_CHAM_CONG = new HashSet<CCTC_BANG_CHAM_CONG>();
            this.CCTC_BANG_LUONG = new HashSet<CCTC_BANG_LUONG>();
            this.XL_DANG_KY_PHE_DUYET = new HashSet<XL_DANG_KY_PHE_DUYET>();
            this.KH_SALES_PHU_TRACH = new HashSet<KH_SALES_PHU_TRACH>();
            this.KHO_CHUYEN_KHO = new HashSet<KHO_CHUYEN_KHO>();
            this.KHO_DNXH = new HashSet<KHO_DNXH>();
            this.KHO_DNXH1 = new HashSet<KHO_DNXH>();
            this.KHO_GIU_HANG = new HashSet<KHO_GIU_HANG>();
            this.KHO_NHAP_KHO = new HashSet<KHO_NHAP_KHO>();
            this.KHO_NHAP_KHO1 = new HashSet<KHO_NHAP_KHO>();
            this.KHO_XUAT_KHO = new HashSet<KHO_XUAT_KHO>();
            this.KHO_XUAT_KHO1 = new HashSet<KHO_XUAT_KHO>();
            this.MENU_USER = new HashSet<MENU_USER>();
            this.MH_MDV = new HashSet<MH_MDV>();
            this.NCC_PUR_PHU_TRACH = new HashSet<NCC_PUR_PHU_TRACH>();
            this.NH_CHUYEN_TIEN_NOI_BO = new HashSet<NH_CHUYEN_TIEN_NOI_BO>();
        }
    
        public string USERNAME { get; set; }
        public string GIOI_TINH { get; set; }
        public Nullable<System.DateTime> NGAY_SINH { get; set; }
        public string QUE_QUAN { get; set; }
        public string CHUC_VU { get; set; }
        public string TRINH_DO_HOC_VAN { get; set; }
        public string THANH_TICH_CONG_TAC { get; set; }
        public string MA_PHONG_BAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BH_BAO_GIA> BH_BAO_GIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BH_DE_NGHI_GIU_HANG> BH_DE_NGHI_GIU_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CCTC_BANG_CHAM_CONG> CCTC_BANG_CHAM_CONG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CCTC_BANG_LUONG> CCTC_BANG_LUONG { get; set; }
        public virtual CCTC_PHONG_BAN CCTC_PHONG_BAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XL_DANG_KY_PHE_DUYET> XL_DANG_KY_PHE_DUYET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_SALES_PHU_TRACH> KH_SALES_PHU_TRACH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_CHUYEN_KHO> KHO_CHUYEN_KHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_DNXH> KHO_DNXH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_DNXH> KHO_DNXH1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_GIU_HANG> KHO_GIU_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_NHAP_KHO> KHO_NHAP_KHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_NHAP_KHO> KHO_NHAP_KHO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_XUAT_KHO> KHO_XUAT_KHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_XUAT_KHO> KHO_XUAT_KHO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU_USER> MENU_USER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MH_MDV> MH_MDV { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NCC_PUR_PHU_TRACH> NCC_PUR_PHU_TRACH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NH_CHUYEN_TIEN_NOI_BO> NH_CHUYEN_TIEN_NOI_BO { get; set; }
        public virtual HT_NGUOI_DUNG HT_NGUOI_DUNG { get; set; }
    }
}
