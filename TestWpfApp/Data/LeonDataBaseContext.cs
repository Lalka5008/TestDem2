using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestWpfApp.Model;

namespace TestWpfApp.Data;

public partial class LeonDataBaseContext : DbContext
{
    public LeonDataBaseContext()
    {
    }

    public LeonDataBaseContext(DbContextOptions<LeonDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Importer> Importers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderInfo> OrderInfos { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductName> ProductNames { get; set; }

    public virtual DbSet<Pvz> Pvzs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<UnitType> UnitTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=LeonDataBase;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC078B0181C8");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Importer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Importer__3214EC07156BBD74");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07CC9BDBCD");

            entity.Property(e => e.Pvzid).HasColumnName("PVZId");

            entity.HasOne(d => d.Pvz).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Pvzid)
                .HasConstraintName("FK__Orders__PVZId__4F7CD00D");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Orders__StatusId__5165187F");

            entity.HasOne(d => d.UserName).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserNameId)
                .HasConstraintName("FK__Orders__UserName__5070F446");
        });

        modelBuilder.Entity<OrderInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderInf__3214EC07AA5D5B22");

            entity.ToTable("OrderInfo");

            entity.Property(e => e.ArticleId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Article).WithMany(p => p.OrderInfos)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK__OrderInfo__Artic__5535A963");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderInfos)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderInfo__Order__5441852A");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producer__3214EC072ADB749C");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Article).HasName("PK__Product__4943444BEE30EC31");

            entity.ToTable("Product");

            entity.Property(e => e.Article)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Info)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__4AB81AF0");

            entity.HasOne(d => d.Importer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ImporterId)
                .HasConstraintName("FK__Product__Importe__48CFD27E");

            entity.HasOne(d => d.Name).WithMany(p => p.Products)
                .HasForeignKey(d => d.NameId)
                .HasConstraintName("FK__Product__NameId__47DBAE45");

            entity.HasOne(d => d.Producer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProducerId)
                .HasConstraintName("FK__Product__Produce__49C3F6B7");

            entity.HasOne(d => d.Unit).WithMany(p => p.Products)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK_Product_UnitType");
        });

        modelBuilder.Entity<ProductName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductN__3214EC07B848E2AF");

            entity.ToTable("ProductName");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pvz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PVZ__3214EC07A18379BC");

            entity.ToTable("PVZ");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC0704B16C0E");

            entity.ToTable("Role");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Statuses__3214EC0780F79821");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UnitType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UnitType__3214EC07BAAA98C4");

            entity.ToTable("UnitType");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07380C9203");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
