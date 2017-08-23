namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            DanhMucCons = new HashSet<DanhMucCon>();
        }

        public int ID { get; set; }

        [StringLength(250)]
        public string TenKHo { get; set; }

        [StringLength(250)]
        public string TenViet { get; set; }

        public int? IDBaiHoc { get; set; }

        public virtual BaiHoc BaiHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCon> DanhMucCons { get; set; }
    }
}
