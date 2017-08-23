namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TuVung")]
    public partial class TuVung
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string KHo { get; set; }

        [StringLength(250)]
        public string Viet { get; set; }

        public int? IDDanhMucCon { get; set; }

        public virtual DanhMucCon DanhMucCon { get; set; }
    }
}
