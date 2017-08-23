namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticker")]
    public partial class Ticker
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public long AccountID { get; set; }

        public bool Status { get; set; }

        public bool? Type { get; set; }

        public long? Quantity { get; set; }

        public decimal Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public virtual Account Account { get; set; }
    }
}
