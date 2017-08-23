namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVietKHo")]
    public partial class DichVietKHo
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Viet { get; set; }

        [Column(TypeName = "ntext")]
        public string KHo { get; set; }

        public int? IDDanhMucCon { get; set; }

        public virtual DanhMucCon DanhMucCon { get; set; }
    }
}
