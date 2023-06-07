namespace apartment.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        [StringLength(10)]
        public string MaHoaDon { get; set; }

        [StringLength(10)]
        public string MaNguoiThue { get; set; }

        [StringLength(10)]
        public string MaPhong { get; set; }

        [StringLength(10)]
        public string MaCTHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTaoHD { get; set; }

        public int? TongChiPhi { get; set; }

        public virtual ChitietHoaDon ChitietHoaDon { get; set; }

        public virtual NguoiThue NguoiThue { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
