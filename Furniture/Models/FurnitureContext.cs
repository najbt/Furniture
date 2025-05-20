using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Furniture.Models;

public partial class FurnitureContext : DbContext
{
    public FurnitureContext()
    {
    }

    public FurnitureContext(DbContextOptions<FurnitureContext> options)
        : base(options)
    {
    }
    //Blog tip Blogs table
    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Furniture> Furnitures { get; set; }

    public virtual DbSet<FurnitureCategory> FurnitureCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=nara;Database=furniture;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__blog__2975AA282BB0F7EB");

            entity.ToTable("blog");

            entity.Property(e => e.BlogId).HasColumnName("blog_id");
            entity.Property(e => e.BlogContent).HasColumnName("blog_content");
            entity.Property(e => e.BlogDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("blog_date");
            entity.Property(e => e.BlogImgUrl)
                .IsUnicode(false)
                .HasColumnName("blog_img_url");
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("blog_title");
        });

        modelBuilder.Entity<Furniture>(entity =>
        {
            entity.HasKey(e => e.FurnitureId).HasName("PK__furnitur__61F2B45379E57C61");

            entity.ToTable("furniture");

            entity.Property(e => e.FurnitureId).HasColumnName("furniture_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.FurnitureImgUrl)
                .IsUnicode(false)
                .HasColumnName("furniture_img_url");
            entity.Property(e => e.FurnitureName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("furniture_name");
            entity.Property(e => e.FurniturePrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("furniture_price");

            entity.HasOne(d => d.Category).WithMany(p => p.Furnitures)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__furniture__categ__4F7CD00D");
        });

        modelBuilder.Entity<FurnitureCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__furnitur__D54EE9B426551107");

            entity.ToTable("furniture_category");

            entity.HasIndex(e => e.CategoryName, "UQ__furnitur__5189E255FC1CBE61").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
