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
    
    public partial class KH_LIEN_HE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH_LIEN_HE()
        {
            this.BH_BAO_GIA = new HashSet<BH_BAO_GIA>();
            this.KH_SALES_PHU_TRACH = new HashSet<KH_SALES_PHU_TRACH>();
        }
    
        public int ID_LIEN_HE { get; set; }
        public string MA_KHACH_HANG { get; set; }
        public string NGUOI_LIEN_HE { get; set; }
        public string CHUC_VU { get; set; }
        public string PHONG_BAN { get; set; }
        public Nullable<System.DateTime> NGAY_SINH { get; set; }
        public string GIOI_TINH { get; set; }
        public string EMAIL_CA_NHAN { get; set; }
        public string EMAIL_CONG_TY { get; set; }
        public string SKYPE { get; set; }
        public string FACEBOOK { get; set; }
        public string GHI_CHU { get; set; }
        public string SDT1 { get; set; }
        public string SDT2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BH_BAO_GIA> BH_BAO_GIA { get; set; }
        public virtual KH KH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_SALES_PHU_TRACH> KH_SALES_PHU_TRACH { get; set; }
    }
}
