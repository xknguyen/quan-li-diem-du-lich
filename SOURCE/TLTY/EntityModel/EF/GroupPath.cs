namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupPath")]
    public partial class GroupPath
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string AccountGroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string PathID { get; set; }
    }
}
