namespace EntityModel.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        [StringLength(50)]
        public string FooterID { get; set; }

        [Column(TypeName = "ntext")]
        public string Contents { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? UserID { get; set; }

        public bool? Status { get; set; }

        public virtual User User { get; set; }
    }
}
