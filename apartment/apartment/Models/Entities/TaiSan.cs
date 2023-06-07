namespace apartment.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiSan")]
    public partial class TaiSan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiSan()
        {
            ChitietHoaDons = new HashSet<ChitietHoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaTaiSan { get; set; }

        [StringLength(250)]
        public string TenTaiSan { get; set; }

        [StringLength(10)]
        public string MaPhong { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        public int? TienDenBu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChitietHoaDon> ChitietHoaDons { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
