namespace apartment.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChitietHoaDon")]
    public partial class ChitietHoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChitietHoaDon()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaCTHD { get; set; }

        [StringLength(10)]
        public string MaDichVu { get; set; }

        [StringLength(10)]
        public string MaNguoiThue { get; set; }

        [StringLength(10)]
        public string MaTaiSan { get; set; }

        public int? GiaThue { get; set; }

        public int? TienNo { get; set; }

        public int? TienTamUng { get; set; }

        public int? TongChiPhi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SoNgayO { get; set; }

        public int? SoTienDaTra { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual NguoiThue NguoiThue { get; set; }

        public virtual TaiSan TaiSan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
