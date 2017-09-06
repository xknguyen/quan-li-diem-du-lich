namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	using System.Web.Mvc;

    [Table("Instruction")]
    public partial class Instruction
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(250)]
        public string UserName { get; set; }

        public bool Status { get; set; }

		[AllowHtml]
        [Column(TypeName = "ntext")]
        [Required]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }
    }
}
