using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebEnterpriseProjectsKMD
{
    public partial class KMDContext : DbContext
    {
        public KMDContext()
        {
        }

        public KMDContext(DbContextOptions<KMDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GostNamber> GostNambers { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<MarksRow> MarksRows { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Part> Parts { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Sortament> Sortaments { get; set; } = null!;
        public virtual DbSet<SteelMaterial> SteelMaterials { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=KMD;Username=postgres;Password=qwe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GostNamber>(entity =>
            {
                entity.ToTable("gost_nambers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gost)
                    .HasMaxLength(30)
                    .HasColumnName("gost");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate).HasColumnName("date_create");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Number)
                    .HasMaxLength(10)
                    .HasColumnName("number");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("marks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.AmountMetiz).HasColumnName("amount_metiz");

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.Coating)
                    .HasMaxLength(20)
                    .HasColumnName("coating");

                entity.Property(e => e.DrawingNamber)
                    .HasMaxLength(10)
                    .HasColumnName("drawing_namber");

                entity.Property(e => e.IsWelding).HasColumnName("is_welding");

                entity.Property(e => e.Marka)
                    .HasMaxLength(20)
                    .HasColumnName("marka");

                entity.Property(e => e.MetizId).HasColumnName("metiz_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PriecesMade).HasColumnName("prieces_made");

                entity.Property(e => e.TotalArea).HasColumnName("total_area");

                entity.Property(e => e.TotalWeight).HasColumnName("total_weight");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<MarksRow>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("marks_rows");

                entity.Property(e => e.AmoubtN).HasColumnName("amoubt_n");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.AmountT).HasColumnName("amount_t");

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.MarkId).HasColumnName("mark_id");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.TotalArea).HasColumnName("total_area");

                entity.Property(e => e.TotalWeight).HasColumnName("total_weight");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate).HasColumnName("date_create");

                entity.Property(e => e.InvenoryId).HasColumnName("invenory_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Number)
                    .HasMaxLength(20)
                    .HasColumnName("number");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("parts");

                entity.Property(e => e.DrawingNamber)
                    .HasMaxLength(15)
                    .HasColumnName("drawing_namber");

                entity.Property(e => e.GostProfile)
                    .HasMaxLength(20)
                    .HasColumnName("gost_profile");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.InventorieId).HasColumnName("inventorie_id");

                entity.Property(e => e.IsRolledSteel).HasColumnName("is_rolled_steel");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note");

                entity.Property(e => e.PaintingArea).HasColumnName("painting_area");

                entity.Property(e => e.Position)
                    .HasMaxLength(10)
                    .HasColumnName("position");

                entity.Property(e => e.SteelMaterial)
                    .HasMaxLength(10)
                    .HasColumnName("steel_material");

                entity.Property(e => e.SteelProfil)
                    .HasMaxLength(50)
                    .HasColumnName("steel_profil");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profiles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompasName)
                    .HasMaxLength(20)
                    .HasColumnName("compas_name");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.ShortName)
                    .HasColumnType("character varying")
                    .HasColumnName("short_name");
            });

            modelBuilder.Entity<Sortament>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sortaments");

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.Density).HasColumnName("density");

                entity.Property(e => e.GostId).HasColumnName("gost_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            });

            modelBuilder.Entity<SteelMaterial>(entity =>
            {
                entity.ToTable("steel_material");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('\"Steel_material_Id_seq\"'::regclass)");

                entity.Property(e => e.Gost)
                    .HasMaxLength(20)
                    .HasColumnName("gost");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
