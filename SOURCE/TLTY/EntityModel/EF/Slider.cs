namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        [StringLength(10)]
        public string Link { get; set; }

        public long ContentID { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(250)]
        public string UserName { get; set; }

        public bool Status { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public virtual Content Content { get; set; }
    }
}
