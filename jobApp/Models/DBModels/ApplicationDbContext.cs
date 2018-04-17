using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using jobApp.Models;

namespace jobApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Annonce> Annonce { get; set; }
        public virtual DbSet<AnnonceKompetence> AnnonceKompetence { get; set; }
        public virtual DbSet<Kompetence> Kompetence { get; set; }
        public virtual DbSet<KompetenceKategorisering> KompetenceKategorisering { get; set; }
        public virtual DbSet<KompetenceProfile> KompetenceProfile { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RegionProfile> RegionProfile { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Annonce>(entity =>
            {
                entity.ToTable("annonce");

                entity.HasIndex(e => e.RegionId)
                    .HasName("region_id_idx");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("blob");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpiringDate)
                    .HasColumnName("expiringDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("timeStamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Annonce)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("region_id");
            });

            modelBuilder.Entity<AnnonceKompetence>(entity =>
            {
                entity.ToTable("annonce_kompetence");

                entity.HasIndex(e => e.AnnonceId)
                    .HasName("activeAnnonce_id_idx");

                entity.HasIndex(e => e.KomptenceId)
                    .HasName("kompetence_id_idx");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.AnnonceId).HasColumnName("annonce_id");

                entity.Property(e => e.KomptenceId).HasColumnName("komptence_id");

                entity.HasOne(d => d.Annonce)
                    .WithMany(p => p.AnnonceKompetence)
                    .HasForeignKey(d => d.AnnonceId)
                    .HasConstraintName("activeAnnonce_id");

                entity.HasOne(d => d.Komptence)
                    .WithMany(p => p.AnnonceKompetence)
                    .HasForeignKey(d => d.KomptenceId)
                    .HasConstraintName("kompetence_id");
            });

            modelBuilder.Entity<Kompetence>(entity =>
            {
                entity.ToTable("kompetence");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(255);

                entity.Property(e => e.ConceptUri)
                    .HasColumnName("conceptUri")
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("blob");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<KompetenceKategorisering>(entity =>
            {
                entity.ToTable("kompetence_kategorisering");

                entity.HasIndex(e => e.Subkompetence)
                    .HasName("fk_Kompetence_has_Kompetence_Kompetence2_idx");

                entity.HasIndex(e => e.Superkompetence)
                    .HasName("fk_Kompetence_has_Kompetence_Kompetence1_idx");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.Subkompetence).HasColumnName("subkompetence");

                entity.Property(e => e.Superkompetence).HasColumnName("superkompetence");

                entity.HasOne(d => d.SubkompetenceNavigation)
                    .WithMany(p => p.KompetenceKategoriseringSubkompetenceNavigation)
                    .HasForeignKey(d => d.Subkompetence)
                    .HasConstraintName("fk_Kompetence_has_Kompetence_Kompetence2");

                entity.HasOne(d => d.SuperkompetenceNavigation)
                    .WithMany(p => p.KompetenceKategoriseringSuperkompetenceNavigation)
                    .HasForeignKey(d => d.Superkompetence)
                    .HasConstraintName("fk_Kompetence_has_Kompetence_Kompetence1");
            });

            modelBuilder.Entity<KompetenceProfile>(entity =>
            {
                entity.ToTable("kompetence_profile");

                entity.HasIndex(e => e.KompetenceprofileId)
                    .HasName("kompetence_id_idx");

                entity.HasIndex(e => e.kompetenceApplicationUserId)
                    .HasName("kompetenceApplicationUserId_idx");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.KompetenceprofileId).HasColumnName("kompetenceprofile_id");

                entity.Property(e => e.kompetenceApplicationUserId).HasColumnName("kompetenceApplicationUserId");

                entity.HasOne(d => d.Kompetenceprofile)
                    .WithMany(p => p.KompetenceProfile)
                    .HasForeignKey(d => d.KompetenceprofileId)
                    .HasConstraintName("kompetenceProfile_id");

                entity.HasOne(d => d.Profilekompetence)
                    .WithMany(p => p.KompetenceProfile)
                    .HasForeignKey(d => d.kompetenceApplicationUserId)
                    .HasConstraintName("kompetenceApplicationUserId");
            });



            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<RegionProfile>(entity =>
            {
                entity.ToTable("region_profile");

                entity.HasIndex(e => e.regionApplicationUserId)
                    .HasName("regionApplicationUserId_idx");

                entity.HasIndex(e => e.RegionProfileId)
                    .HasName("region_id_idx");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.regionApplicationUserId).HasColumnName("regionApplicationUserId");

                entity.Property(e => e.RegionProfileId).HasColumnName("regionProfile_id");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.RegionProfile)
                    .HasForeignKey(d => d.regionApplicationUserId)
                    .HasConstraintName("regionApplicationUserId");

                entity.HasOne(d => d.RegionProfileNavigation)
                    .WithMany(p => p.RegionProfile)
                    .HasForeignKey(d => d.RegionProfileId)
                    .HasConstraintName("regionProfile_id");
            });
        }
    }
}
