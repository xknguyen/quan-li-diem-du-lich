namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invest")]
    public partial class Invest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public DateTime? CreateDate { get; set; }

        public long? AccountID { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public virtual Account Account { get; set; }
    }
}
