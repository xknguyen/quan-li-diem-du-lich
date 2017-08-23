namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoiHayYDep")]
    public partial class LoiHayYDep
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string CauKHo { get; set; }

        [Column(TypeName = "ntext")]
        public string CauViet { get; set; }

        public int? IDBaiHoc { get; set; }

        public virtual BaiHoc BaiHoc { get; set; }
    }
}
