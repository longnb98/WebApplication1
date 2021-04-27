using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Model
{
    public partial class QLSINHVIENContext : DbContext
    {
        public QLSINHVIENContext()
        {
        }

        public QLSINHVIENContext(DbContextOptions<QLSINHVIENContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ketqua> Ketqua { get; set; }
        public virtual DbSet<Khoa> Khoa { get; set; }
        public virtual DbSet<MonHoc> MonHoc { get; set; }
        public virtual DbSet<SinhVien> SinhVien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=QLSINHVIEN;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ketqua>(entity =>
            {
                entity.HasKey(e => new { e.MaSv, e.MaMh })
                    .HasName("Prk_MaSV_MAMH");

                entity.Property(e => e.MaSv)
                    .HasColumnName("MaSV")
                    .HasMaxLength(3);

                entity.Property(e => e.MaMh)
                    .HasColumnName("MaMH")
                    .HasMaxLength(2);

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.Ketqua)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Frk_KetQua_Mamh");

                entity.HasOne(d => d.MaSvNavigation)
                    .WithMany(p => p.Ketqua)
                    .HasForeignKey(d => d.MaSv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Frk_KetQua_Makh");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("Prk_KHOA_khoa");

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(2);

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasColumnName("TenKH")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("Prk_MONHOC_MaMH");

                entity.Property(e => e.MaMh)
                    .HasColumnName("MaMH")
                    .HasMaxLength(2);

                entity.Property(e => e.TenMh)
                    .IsRequired()
                    .HasColumnName("TenMH")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSv)
                    .HasName("Prk_SINHVIEN_MaSV");

                entity.Property(e => e.MaSv)
                    .HasColumnName("MaSV")
                    .HasMaxLength(3);

                entity.Property(e => e.HoSv)
                    .IsRequired()
                    .HasColumnName("HoSV")
                    .HasMaxLength(15);

                entity.Property(e => e.HocBong).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaKh)
                    .IsRequired()
                    .HasColumnName("MaKH")
                    .HasMaxLength(2);

                entity.Property(e => e.NgaySinh).HasColumnType("smalldatetime");

                entity.Property(e => e.NoiSinh)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TenSv)
                    .IsRequired()
                    .HasColumnName("TenSV")
                    .HasMaxLength(7);

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.SinhVien)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Frk_SINHVIEN_Makh");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
