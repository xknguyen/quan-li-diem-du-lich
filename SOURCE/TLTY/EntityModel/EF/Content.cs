namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Content()
        {
            Requests = new HashSet<Request>();
            Sliders = new HashSet<Slider>();
        }

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
        public string Detail { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public bool Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Slider> Sliders { get; set; }
    }
}
