namespace EntityModel.EFModel
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class DiemDuLichDBContext : DbContext
	{
		public DiemDuLichDBContext()
			: base("name=DiemDuLichDBContext")
		{
		}

		public virtual DbSet<AlbumImage> AlbumImages { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }
		public virtual DbSet<Content> Contents { get; set; }
		public virtual DbSet<ContentTag> ContentTags { get; set; }
		public virtual DbSet<Feedback> Feedbacks { get; set; }
		public virtual DbSet<Footer> Footers { get; set; }
		public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<Slider> Sliders { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Content>()
				.Property(e => e.ModifiedBy)
				.IsUnicode(false);

			modelBuilder.Entity<Tag>()
				.Property(e => e.ID)
				.IsUnicode(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.Menus)
				.WithRequired(e => e.User)
				.WillCascadeOnDelete(false);
		}
	}
}
