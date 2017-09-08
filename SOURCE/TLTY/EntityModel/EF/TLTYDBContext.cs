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
		public virtual DbSet<AccountGroup> AccountGroups { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }
		public virtual DbSet<Content> Contents { get; set; }
		public virtual DbSet<Feedback> Feedbacks { get; set; }
		public virtual DbSet<GroupPath> GroupPaths { get; set; }
		public virtual DbSet<Instruction> Instructions { get; set; }
		public virtual DbSet<Path> Paths { get; set; }
		public virtual DbSet<Request> Requests { get; set; }
		public virtual DbSet<Slider> Sliders { get; set; }
		public virtual DbSet<Ticker> Tickers { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Ticker>()
				.Property(e => e.Price)
				.HasPrecision(18, 0);
		}
	}
}
