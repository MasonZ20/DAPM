//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace apartment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            this.ChitietHoaDons = new HashSet<ChitietHoaDon>();
        }
    
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public Nullable<int> GiaDichVu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChitietHoaDon> ChitietHoaDons { get; set; }
    }
}
