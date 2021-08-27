using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ObezIndexAPI.Models
{
    public partial class ObezIndex1Context : DbContext
    {
        public ObezIndex1Context()
        {
        }

        public ObezIndex1Context(DbContextOptions<ObezIndex1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Consults> Consults { get; set; }
        public virtual DbSet<Doktor> Doktor { get; set; }
        public virtual DbSet<Hasta> Hasta { get; set; }
        public virtual DbSet<HastaHas> HastaHas { get; set; }
        public virtual DbSet<Hastalik> Hastalik { get; set; }
        public virtual DbSet<Tani> Tani { get; set; }
        public virtual DbSet<TaniKoyma> TaniKoyma { get; set; }
        public virtual DbSet<Tedavi> Tedavi { get; set; }
        public virtual DbSet<TedaviUyg> TedaviUyg { get; set; }
        public virtual DbSet<Uzmanlik> Uzmanlik { get; set; }
        public virtual DbSet<UzmanlikHas> UzmanlikHas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=ObezIndex1;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consults>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DocId).HasColumnName("doc_ID");

                entity.Property(e => e.PatId).HasColumnName("pat_ID");
            });

            modelBuilder.Entity<Doktor>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.Property(e => e.DocId).HasColumnName("doc_ID");

                entity.Property(e => e.DocAddress).HasColumnName("doc_address");

                entity.Property(e => e.DocInfo).HasColumnName("doc_info");

                entity.Property(e => e.DocName).HasColumnName("doc_name");

                entity.Property(e => e.DocPassword).HasColumnName("doc_password");

                entity.Property(e => e.DocProfession).HasColumnName("doc_profession");

                entity.Property(e => e.DocTitle).HasColumnName("doc_title");

                entity.Property(e => e.DocUsername).HasColumnName("doc_username");
            });

            modelBuilder.Entity<Hasta>(entity =>
            {
                entity.HasKey(e => e.PatId);

                entity.Property(e => e.PatId).HasColumnName("pat_ID");

                entity.Property(e => e.PatAddress).HasColumnName("pat_address");

                entity.Property(e => e.PatAge).HasColumnName("pat_age");

                entity.Property(e => e.PatGender).HasColumnName("pat_gender");

                entity.Property(e => e.PatHeight).HasColumnName("pat_height");

                entity.Property(e => e.PatInfo).HasColumnName("pat_info");

                entity.Property(e => e.PatName).HasColumnName("pat_name");

                entity.Property(e => e.PatPassword).HasColumnName("pat_password");

                entity.Property(e => e.PatUsername).HasColumnName("pat_username");

                entity.Property(e => e.PatWeight).HasColumnName("pat_weight");
            });

            modelBuilder.Entity<HastaHas>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IllId).HasColumnName("ill_ID");

                entity.Property(e => e.PatId).HasColumnName("pat_ID");
            });

            modelBuilder.Entity<Hastalik>(entity =>
            {
                entity.HasKey(e => e.IllId);

                entity.Property(e => e.IllId).HasColumnName("ill_ID");

                entity.Property(e => e.IllCategory).HasColumnName("ill_category");

                entity.Property(e => e.IllDescription).HasColumnName("ill_description");

                entity.Property(e => e.IllName).HasColumnName("ill_name");
            });

            modelBuilder.Entity<Tani>(entity =>
            {
                entity.HasKey(e => e.DgnId);

                entity.Property(e => e.DgnId).HasColumnName("dgn_ID");

                entity.Property(e => e.DgnInfo).HasColumnName("dgn_info");
            });

            modelBuilder.Entity<TaniKoyma>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DgnId).HasColumnName("dgn_ID");

                entity.Property(e => e.DocId).HasColumnName("doc_ID");

                entity.Property(e => e.PatId).HasColumnName("pat_ID");
            });

            modelBuilder.Entity<Tedavi>(entity =>
            {
                entity.HasKey(e => e.TmtId);

                entity.Property(e => e.TmtId).HasColumnName("tmt_ID");

                entity.Property(e => e.TmtInfo).HasColumnName("tmt_info");
            });

            modelBuilder.Entity<TedaviUyg>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DocId).HasColumnName("doc_ID");

                entity.Property(e => e.IllId).HasColumnName("ill_ID");

                entity.Property(e => e.PatId).HasColumnName("pat_ID");

                entity.Property(e => e.TmtDate).HasColumnName("tmt_date");
            });

            modelBuilder.Entity<Uzmanlik>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.Property(e => e.ProId).HasColumnName("pro_ID");

                entity.Property(e => e.ProInfo).HasColumnName("pro_info");
            });

            modelBuilder.Entity<UzmanlikHas>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DocId).HasColumnName("doc_ID");

                entity.Property(e => e.ProId).HasColumnName("pro_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
