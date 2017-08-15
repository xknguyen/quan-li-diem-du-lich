namespace ModelEF.Model
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class DiemDLDBContext : DbContext
	{
		public DiemDLDBContext()
			: base("name=DiemDLDBContext")
		{
		}

		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }
		public virtual DbSet<Content> Contents { get; set; }
		public virtual DbSet<Feedback> Feedbacks { get; set; }
		public virtual DbSet<Invest> Invests { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<Slider> Sliders { get; set; }
		public virtual DbSet<Ticker> Tickers { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>()
				.HasMany(e => e.Menus)
				.WithRequired(e => e.Account)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Ticker>()
				.Property(e => e.Price)
				.HasPrecision(18, 0);
		}
	}
}
