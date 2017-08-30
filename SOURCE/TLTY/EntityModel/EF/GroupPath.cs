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
        public long ID { get; set; }

		[StringLength(250)]
		public string Name { get; set; }

        public long? GroupID { get; set; }

        public long? PathID { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }

        public virtual Path Path { get; set; }
    }
}
