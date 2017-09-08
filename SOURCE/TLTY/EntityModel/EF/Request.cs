namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Status { get; set; }

        public long? ContentID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

		[Column(TypeName = "xml")]
		public string MoreImages { get; set; }
    }
}
