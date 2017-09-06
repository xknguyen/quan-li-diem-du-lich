namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Path")]
    public partial class Path
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
    }
}
