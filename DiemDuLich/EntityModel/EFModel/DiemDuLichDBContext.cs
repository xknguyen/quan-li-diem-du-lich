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

		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Client> Clients { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }
		public virtual DbSet<Content> Contents { get; set; }
		public virtual DbSet<Feedback> Feedbacks { get; set; }
		public virtual DbSet<Footer> Footers { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<OrderDetail> OrderDetails { get; set; }
		public virtual DbSet<Slider> Sliders { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<Ticket> Tickets { get; set; }
		public virtual DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Content>()
				.HasMany(e => e.Tags1)
				.WithMany(e => e.Contents)
				.Map(m => m.ToTable("ContentTag").MapLeftKey("ContentID").MapRightKey("TagID"));

			modelBuilder.Entity<Order>()
				.Property(e => e.TotalPrice)
				.HasPrecision(18, 0);

			modelBuilder.Entity<Order>()
				.HasMany(e => e.OrderDetails)
				.WithRequired(e => e.Order)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<OrderDetail>()
				.Property(e => e.Price)
				.HasPrecision(18, 0);

			modelBuilder.Entity<Ticket>()
				.Property(e => e.Price)
				.HasPrecision(18, 0);

			modelBuilder.Entity<Ticket>()
				.HasMany(e => e.OrderDetails)
				.WithRequired(e => e.Ticket)
				.HasForeignKey(e => e.TickerID)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.Menus)
				.WithRequired(e => e.User)
				.WillCascadeOnDelete(false);
		}
	}
}
