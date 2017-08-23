namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiKhoa")]
    public partial class BaiKhoa
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string HoiKHo { get; set; }

        [Column(TypeName = "ntext")]
        public string TraLoiKHo { get; set; }

        [Column(TypeName = "ntext")]
        public string HoiViet { get; set; }

        [Column(TypeName = "ntext")]
        public string TraLoiViet { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public int? IDDanhMucCon { get; set; }

        public virtual DanhMucCon DanhMucCon { get; set; }
    }
}
