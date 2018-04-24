using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace jobApp.Models.DBModels
{
    public partial class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Annonce> Annonce { get; set; }
        public virtual DbSet<AnnonceKompetence> AnnonceKompetence { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Kompetence> Kompetence { get; set; }
        public virtual DbSet<KompetenceKategorisering> KompetenceKategorisering { get; set; }
        public virtual DbSet<Kompetenceprofile> Kompetenceprofile { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Regionprofile> Regionprofile { get; set; }
        public virtual DbSet<SkillsDaFixed> SkillsDaFixed { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)

        {

        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySql("Server=localhost;Database=jobdbtest;User ID='root';Password='6bc45b81';");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Annonce>(entity =>
            {
                entity.ToTable("annonce");

                entity.HasIndex(e => e.RegionId)
                    .HasName("region_id_idx");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.Checksum)
                    .HasColumnName("checksum")
                    .HasColumnType("text");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("timeStamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("text");

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

           

           
            

            
           

            

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(95);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Kompetence>(entity =>
            {
                entity.ToTable("kompetence");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.AltLabels)
                    .HasColumnName("altLabels")
                    .HasMaxLength(255);

                entity.Property(e => e.ConceptUri)
                    .HasColumnName("conceptUri")
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("blob");

                entity.Property(e => e.Kompetencecol)
                    .HasColumnName("kompetencecol")
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.PrefferredLabel)
                    .HasColumnName("prefferredLabel")
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

            modelBuilder.Entity<Kompetenceprofile>(entity =>
            {
                entity.ToTable("kompetenceprofile");

                entity.HasIndex(e => e.KompetenceprofileId)
                    .HasName("IX_KompetenceProfile_KompetenceprofileId");

                entity.HasIndex(e => e.ProfilekompetenceId)
                    .HasName("IX_KompetenceProfile_ProfilekompetenceId");

                entity.Property(e => e.KompetenceApplicationUserId).HasColumnName("kompetenceApplicationUserId");

                entity.HasOne(d => d.KompetenceprofileNavigation)
                    .WithMany(p => p.Kompetenceprofile)
                    .HasForeignKey(d => d.KompetenceprofileId)
                    .HasConstraintName("FK_KompetenceProfile_kompetence_KompetenceprofileId");

                entity.HasOne(d => d.Profilekompetence)
                    .WithMany(p => p.KompetenceProfile)
                    .HasForeignKey(d => d.ProfilekompetenceId)
                    .HasConstraintName("FK_KompetenceProfile_AspNetUsers_ProfilekompetenceId");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Regionprofile>(entity =>
            {
                entity.ToTable("regionprofile");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("IX_RegionProfile_ProfileId");

                entity.HasIndex(e => e.RegionProfileNavigationRegionId)
                    .HasName("IX_RegionProfile_RegionProfileNavigationRegionId");

                entity.Property(e => e.RegionApplicationUserId).HasColumnName("regionApplicationUserId");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.RegionProfile)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_RegionProfile_AspNetUsers_ProfileId");

                entity.HasOne(d => d.RegionProfileNavigationRegion)
                    .WithMany(p => p.Regionprofile)
                    .HasForeignKey(d => d.RegionProfileNavigationRegionId)
                    .HasConstraintName("FK_RegionProfile_region_RegionProfileNavigationRegionId");
            });

            modelBuilder.Entity<SkillsDaFixed>(entity =>
            {
                entity.ToTable("skills_da_fixed");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.AltLabels)
                    .HasColumnName("altLabels")
                    .HasColumnType("text");

                entity.Property(e => e.ConceptType)
                    .HasColumnName("conceptType")
                    .HasColumnType("text");

                entity.Property(e => e.ConceptUri)
                    .HasColumnName("conceptUri")
                    .HasColumnType("text");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.PreferredLabel)
                    .HasColumnName("preferredLabel")
                    .HasColumnType("text");

                entity.Property(e => e.ReuseLevel)
                    .HasColumnName("reuseLevel")
                    .HasColumnType("text");

                entity.Property(e => e.SkillType)
                    .HasColumnName("skillType")
                    .HasColumnType("text");
            });
        }
    }
}
