namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hinh")]
    public partial class Hinh
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string TenHinh { get; set; }

        [Column(TypeName = "ntext")]
        public string DuongDan { get; set; }
    }
}
