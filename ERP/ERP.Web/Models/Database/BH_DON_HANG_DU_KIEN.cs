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
    
    public partial class BH_DON_HANG_DU_KIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BH_DON_HANG_DU_KIEN()
        {
            this.BH_BAO_GIA = new HashSet<BH_BAO_GIA>();
            this.KHO_DNXH = new HashSet<KHO_DNXH>();
        }
    
        public string MA_DU_KIEN { get; set; }
        public string MA_KHACH_HANG { get; set; }
        public bool THANH_CONG { get; set; }
        public bool THAT_BAI { get; set; }
        public string LY_DO_THAT_BAI { get; set; }
        public string TRUC_THUOC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BH_BAO_GIA> BH_BAO_GIA { get; set; }
        public virtual KH KH { get; set; }
        public virtual CCTC_CONG_TY CCTC_CONG_TY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO_DNXH> KHO_DNXH { get; set; }
    }
}
