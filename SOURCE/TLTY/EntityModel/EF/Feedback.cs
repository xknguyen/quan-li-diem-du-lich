namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Status { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Description { get; set; }
    }
}
