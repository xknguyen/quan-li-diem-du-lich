namespace EntityModel.EF
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class TLTYDBContext : DbContext
	{
		public TLTYDBContext()
			: base("name=TLTYDBContext")
		{
		}

		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }
		public virtual DbSet<Content> Contents { get; set; }
		public virtual DbSet<Feedback> Feedbacks { get; set; }
		public virtual DbSet<Instruction> Instructions { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<Request> Requests { get; set; }
		public virtual DbSet<Slider> Sliders { get; set; }
		public virtual DbSet<Ticker> Tickers { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>()
				.HasMany(e => e.Contacts)
				.WithRequired(e => e.Account)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Account>()
				.HasMany(e => e.Contents)
				.WithRequired(e => e.Account)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Account>()
				.HasMany(e => e.Instructions)
				.WithRequired(e => e.Account)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Account>()
				.HasMany(e => e.Menus)
				.WithRequired(e => e.Account)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Account>()
				.HasMany(e => e.Sliders)
				.WithRequired(e => e.Account)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Account>()
				.HasMany(e => e.Tickers)
				.WithRequired(e => e.Account)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Content>()
				.HasMany(e => e.Feedbacks)
				.WithRequired(e => e.Content)
				.HasForeignKey(e => e.IDContent)
				.WillCascadeOnDelete(false);
		}
	}
}
