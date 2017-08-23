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

		public virtual DbSet<BaiHoc> BaiHocs { get; set; }
		public virtual DbSet<BaiKhoa> BaiKhoas { get; set; }
		public virtual DbSet<CauHoi> CauHois { get; set; }
		public virtual DbSet<DamThoai> DamThoais { get; set; }
		public virtual DbSet<DanhMuc> DanhMucs { get; set; }
		public virtual DbSet<DanhMucCon> DanhMucCons { get; set; }
		public virtual DbSet<DichKHoViet> DichKHoViets { get; set; }
		public virtual DbSet<DichVietKHo> DichVietKHoes { get; set; }
		public virtual DbSet<Hinh> Hinhs { get; set; }
		public virtual DbSet<LoiHayYDep> LoiHayYDeps { get; set; }
		public virtual DbSet<LuyenTap> LuyenTaps { get; set; }
		public virtual DbSet<TuVung> TuVungs { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BaiHoc>()
				.HasMany(e => e.DanhMucs)
				.WithOptional(e => e.BaiHoc)
				.HasForeignKey(e => e.IDBaiHoc);

			modelBuilder.Entity<BaiHoc>()
				.HasMany(e => e.LoiHayYDeps)
				.WithOptional(e => e.BaiHoc)
				.HasForeignKey(e => e.IDBaiHoc);

			modelBuilder.Entity<DanhMuc>()
				.HasMany(e => e.DanhMucCons)
				.WithOptional(e => e.DanhMuc)
				.HasForeignKey(e => e.IDDanhMuc);

			modelBuilder.Entity<DanhMucCon>()
				.HasMany(e => e.BaiKhoas)
				.WithOptional(e => e.DanhMucCon)
				.HasForeignKey(e => e.IDDanhMucCon);

			modelBuilder.Entity<DanhMucCon>()
				.HasMany(e => e.CauHois)
				.WithOptional(e => e.DanhMucCon)
				.HasForeignKey(e => e.IDDanhMucCon);

			modelBuilder.Entity<DanhMucCon>()
				.HasMany(e => e.DamThoais)
				.WithOptional(e => e.DanhMucCon)
				.HasForeignKey(e => e.IDDanhMucCon);

			modelBuilder.Entity<DanhMucCon>()
				.HasMany(e => e.DichKHoViets)
				.WithOptional(e => e.DanhMucCon)
				.HasForeignKey(e => e.IDDanhMucCon);

			modelBuilder.Entity<DanhMucCon>()
				.HasMany(e => e.DichVietKHoes)
				.WithOptional(e => e.DanhMucCon)
				.HasForeignKey(e => e.IDDanhMucCon);

			modelBuilder.Entity<DanhMucCon>()
				.HasMany(e => e.LuyenTaps)
				.WithOptional(e => e.DanhMucCon)
				.HasForeignKey(e => e.IDDanhMucCon);

			modelBuilder.Entity<DanhMucCon>()
				.HasMany(e => e.TuVungs)
				.WithOptional(e => e.DanhMucCon)
				.HasForeignKey(e => e.IDDanhMucCon);
		}
	}
}
