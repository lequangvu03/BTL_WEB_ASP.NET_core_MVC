using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartWatch_MVC.Models;

namespace SmartWatch_MVC.Models
{
    public partial class QLBanDongHoContext : DbContext
    {
        public QLBanDongHoContext()
        {
        }

        public QLBanDongHoContext(DbContextOptions<QLBanDongHoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAnhSp> TAnhSps { get; set; } = null!;
        public virtual DbSet<TChatLieu> TChatLieus { get; set; } = null!;
        public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; } = null!;
        public virtual DbSet<TDanhMucSp> TDanhMucSps { get; set; } = null!;
        public virtual DbSet<TGioHang> TGioHangs { get; set; } = null!;
        public virtual DbSet<THangSx> THangSxes { get; set; } = null!;
        public virtual DbSet<THoaDonBan> THoaDonBans { get; set; } = null!;
        public virtual DbSet<TKhachHang> TKhachHangs { get; set; } = null!;
        public virtual DbSet<TKichThuoc> TKichThuocs { get; set; } = null!;
        public virtual DbSet<TLoaiDt> TLoaiDts { get; set; } = null!;
        public virtual DbSet<TLoaiSp> TLoaiSps { get; set; } = null!;
        public virtual DbSet<TMauSac> TMauSacs { get; set; } = null!;
        public virtual DbSet<TNhanVien> TNhanViens { get; set; } = null!;
        public virtual DbSet<TQuocGium> TQuocGia { get; set; } = null!;
        public virtual DbSet<TUser> TUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-1SOFRQ1F\\TUNGLE;Initial Catalog=QLBanDongHo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAnhSp>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.TenFileAnh })
                    .HasName("PK__tAnhSP__2FC2FB7EFA48243A");

                entity.ToTable("tAnhSP");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.TenFileAnh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TChatLieu>(entity =>
            {
                entity.HasKey(e => e.MaChatLieu)
                    .HasName("PK__tChatLie__453995BC2DF41EAE");

                entity.ToTable("tChatLieu");

                entity.Property(e => e.MaChatLieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChatLieu).HasMaxLength(150);
            });

            modelBuilder.Entity<TChiTietHdb>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDon, e.MaSp })
                    .HasName("PK__tChiTiet__512C81BA1EF21298");

                entity.ToTable("tChiTietHDB");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.DonGiaBan).HasColumnType("money");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.TChiTietHdbs)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tChiTietH__MaHoa__6C190EBB");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.TChiTietHdbs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tChiTietHD__MaSP__6D0D32F4");
            });

            modelBuilder.Entity<TDanhMucSp>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__tDanhMuc__2725081C08193AA0");

                entity.ToTable("tDanhMucSP");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GiaLonNhat).HasColumnType("money");

                entity.Property(e => e.GiaNhoNhat).HasColumnType("money");

                entity.Property(e => e.GioiThieuSp)
                    .HasMaxLength(255)
                    .HasColumnName("GioiThieuSP");

                entity.Property(e => e.MaChatLieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaDacTinh)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaDt)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaDT")
                    .IsFixedLength();

                entity.Property(e => e.MaHangSx)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaHangSX")
                    .IsFixedLength();

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaNuocSx)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaNuocSX")
                    .IsFixedLength();

                entity.Property(e => e.TenSp)
                    .HasMaxLength(150)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.MaChatLieuNavigation)
                    .WithMany(p => p.TDanhMucSps)
                    .HasForeignKey(d => d.MaChatLieu)
                    .HasConstraintName("FK__tDanhMucS__MaCha__619B8048");

                entity.HasOne(d => d.MaDtNavigation)
                    .WithMany(p => p.TDanhMucSps)
                    .HasForeignKey(d => d.MaDt)
                    .HasConstraintName("FK__tDanhMucSP__MaDT__6477ECF3");

                entity.HasOne(d => d.MaHangSxNavigation)
                    .WithMany(p => p.TDanhMucSps)
                    .HasForeignKey(d => d.MaHangSx)
                    .HasConstraintName("FK__tDanhMucS__MaHan__628FA481");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.TDanhMucSps)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK__tDanhMucS__MaLoa__6383C8BA");

                entity.HasOne(d => d.MaNuocSxNavigation)
                    .WithMany(p => p.TDanhMucSps)
                    .HasForeignKey(d => d.MaNuocSx)
                    .HasConstraintName("FK__tDanhMucS__MaNuo__656C112C");
            });

            modelBuilder.Entity<TGioHang>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__tGioHang__2725081CDA0DFB44");

                entity.ToTable("tGioHang");

                entity.Property(e => e.MaSp)
                    .ValueGeneratedNever()
                    .HasColumnName("MaSP");

                entity.Property(e => e.GiaBan).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TGioHangs)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK_GioHang_KhachHang");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithOne(p => p.TGioHang)
                    .HasForeignKey<TGioHang>(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GioHang_DanhMucSP");
            });

            modelBuilder.Entity<THangSx>(entity =>
            {
                entity.HasKey(e => e.MaHangSx)
                    .HasName("PK__tHangSX__8C6D28FEB97092C9");

                entity.ToTable("tHangSX");

                entity.Property(e => e.MaHangSx)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaHangSX")
                    .IsFixedLength();

                entity.Property(e => e.HangSx)
                    .HasMaxLength(100)
                    .HasColumnName("HangSX");

                entity.Property(e => e.MaNuocThuongHieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNuocThuongHieuNavigation)
                    .WithMany(p => p.THangSxes)
                    .HasForeignKey(d => d.MaNuocThuongHieu)
                    .HasConstraintName("FK__tHangSX__MaNuocT__5EBF139D");
            });

            modelBuilder.Entity<THoaDonBan>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK__tHoaDonB__835ED13BB925F0B6");

                entity.ToTable("tHoaDonBan");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.GiamGiaHd).HasColumnName("GiamGiaHD");

                entity.Property(e => e.MaSoThue)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");

                entity.Property(e => e.ThongTinThue).HasMaxLength(250);

                entity.Property(e => e.TongTienHd)
                    .HasColumnType("money")
                    .HasColumnName("TongTienHD");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.THoaDonBans)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK__tHoaDonBa__MaKha__68487DD7");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.THoaDonBans)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK__tHoaDonBa__MaNha__693CA210");
            });

            modelBuilder.Entity<TKhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhanhHang)
                    .HasName("PK__tKhachHa__44A558E495A99CB1");

                entity.ToTable("tKhachHang");

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(150);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenKhachHang).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.TKhachHangs)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__tKhachHan__usern__4F7CD00D");
            });

            modelBuilder.Entity<TKichThuoc>(entity =>
            {
                entity.HasKey(e => e.MaKichThuoc)
                    .HasName("PK__tKichThu__22BFD6643DA972E2");

                entity.ToTable("tKichThuoc");

                entity.Property(e => e.MaKichThuoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.KichThuoc)
                    .HasMaxLength(150)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TLoaiDt>(entity =>
            {
                entity.HasKey(e => e.MaDt)
                    .HasName("PK__tLoaiDT__2725865568CDD8D6");

                entity.ToTable("tLoaiDT");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaDT")
                    .IsFixedLength();

                entity.Property(e => e.TenLoai).HasMaxLength(100);
            });

            modelBuilder.Entity<TLoaiSp>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK__tLoaiSP__730A5759E0C9A6B1");

                entity.ToTable("tLoaiSP");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Loai).HasMaxLength(100);

                entity.Property(e => e.TenFileAnh).HasMaxLength(255);
            });

            modelBuilder.Entity<TMauSac>(entity =>
            {
                entity.HasKey(e => e.MaMauSac)
                    .HasName("PK__tMauSac__B9A911621C94880D");

                entity.ToTable("tMauSac");

                entity.Property(e => e.MaMauSac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenMauSac).HasMaxLength(100);
            });

            modelBuilder.Entity<TNhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__tNhanVie__77B2CA47CC01D969");

                entity.ToTable("tNhanVien");

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChucVu).HasMaxLength(100);

                entity.Property(e => e.DiaChi).HasMaxLength(150);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenNhanVien).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.TNhanViens)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__tNhanVien__usern__59FA5E80");
            });

            modelBuilder.Entity<TQuocGium>(entity =>
            {
                entity.HasKey(e => e.MaNuoc)
                    .HasName("PK__tQuocGia__21306FEA056E2D30");

                entity.ToTable("tQuocGia");

                entity.Property(e => e.MaNuoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenNuoc).HasMaxLength(100);
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__tUser__F3DBC5733093726B");

                entity.ToTable("tUser");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
