namespace EntityModel.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TickerID { get; set; }

        [StringLength(250)]
        public string ContentName { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
