namespace EntityModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        public string UserName { get; set; }

        [Required]
        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(50)]
        public string AccountGroupID { get; set; }

        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Avatar { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool Status { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }
    }
}
