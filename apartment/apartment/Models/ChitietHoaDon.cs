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
    
    public partial class ChitietHoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChitietHoaDon()
        {
            this.HoaDons = new HashSet<HoaDon>();
        }
    
        public string MaCTHD { get; set; }
        public string MaDichVu { get; set; }
        public string MaNguoiThue { get; set; }
        public string MaTaiSan { get; set; }
        public Nullable<int> GiaThue { get; set; }
        public Nullable<int> TienNo { get; set; }
        public Nullable<int> TienTamUng { get; set; }
        public Nullable<int> TongChiPhi { get; set; }
        public Nullable<System.DateTime> NgayThue { get; set; }
        public Nullable<System.DateTime> SoNgayO { get; set; }
        public Nullable<int> SoTienDaTra { get; set; }
    
        public virtual DichVu DichVu { get; set; }
        public virtual NguoiThue NguoiThue { get; set; }
        public virtual TaiSan TaiSan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}