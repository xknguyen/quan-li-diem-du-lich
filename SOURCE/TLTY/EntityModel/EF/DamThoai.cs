namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DamThoai")]
    public partial class DamThoai
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string CauHoiKHo { get; set; }

        [Column(TypeName = "ntext")]
        public string TraLoiKHo { get; set; }

        [Column(TypeName = "ntext")]
        public string CauHoiViet { get; set; }

        [Column(TypeName = "ntext")]
        public string TraLoiViet { get; set; }

        public int? IDDanhMucCon { get; set; }

        public virtual DanhMucCon DanhMucCon { get; set; }
    }
}
