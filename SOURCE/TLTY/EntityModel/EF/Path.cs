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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Path()
        {
            GroupPaths = new HashSet<GroupPath>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        public string PathName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(150)]
        public string Link { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupPath> GroupPaths { get; set; }
    }
}
