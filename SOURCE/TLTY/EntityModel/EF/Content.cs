namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	using System.Web.Mvc;

    [Table("Content")]
    public partial class Content
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(250)]
        public string UserName { get; set; }

        public bool Status { get; set; }

        public int? ViewCount { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
		[AllowHtml]
        public string Detail { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public bool Category { get; set; }

    }
}
