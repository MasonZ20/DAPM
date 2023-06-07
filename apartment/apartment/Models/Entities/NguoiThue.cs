namespace apartment.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiThue")]
    public partial class NguoiThue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiThue()
        {
            ChitietHoaDons = new HashSet<ChitietHoaDon>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaNguoiThue { get; set; }

        public int? MaDatPhong { get; set; }

        [StringLength(30)]
        public string HoTen { get; set; }

        [StringLength(35)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(20)]
        public string CMND { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChitietHoaDon> ChitietHoaDons { get; set; }

        public virtual DatPhong DatPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
