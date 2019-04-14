using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LMS.Models.LMSModels
{
    public partial class Team77LMSContext : DbContext
    {
        public Team77LMSContext()
        {
        }

        public Team77LMSContext(DbContextOptions<Team77LMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrators> Administrators { get; set; }
        public virtual DbSet<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EnrollmentGrade> EnrollmentGrade { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Submission> Submission { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=atr.eng.utah.edu;User Id=u1193853;Password=nba180287;Database=Team77LMS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrators>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UId)
                    .HasName("uID")
                    .IsUnique();

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Administrators)
                    .HasForeignKey<Administrators>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Administrators_ibfk_1");
            });

            modelBuilder.Entity<AssignmentCategories>(entity =>
            {
                entity.HasKey(e => e.AcId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CId)
                    .HasName("cID");

                entity.HasIndex(e => new { e.Name, e.CId })
                    .HasName("Name")
                    .IsUnique();

                entity.Property(e => e.AcId)
                    .HasColumnName("acID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CId)
                    .HasColumnName("cID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Weight).HasColumnType("tinyint(4)");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.AssignmentCategories)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AssignmentCategories_ibfk_1");
            });

            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.AcId)
                    .HasName("acID");

                entity.Property(e => e.AId)
                    .HasColumnName("aID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcId)
                    .HasColumnName("acID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.Due)
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Points).HasColumnType("int(11)");

                entity.HasOne(d => d.Ac)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.AcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Assignments_ibfk_1");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UId)
                    .HasName("uID");

                entity.HasIndex(e => new { e.CatalogId, e.Semester })
                    .HasName("CatalogID")
                    .IsUnique();

                entity.Property(e => e.CId)
                    .HasColumnName("cID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CatalogId)
                    .IsRequired()
                    .HasColumnName("CatalogID")
                    .HasColumnType("char(5)");

                entity.Property(e => e.End).HasColumnType("time");

                entity.Property(e => e.Loc)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasColumnType("varchar(14)");

                entity.Property(e => e.Start).HasColumnType("time");

                entity.Property(e => e.UId)
                    .IsRequired()
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_ibfk_2");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CatalogId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CatalogId)
                    .HasName("CatalogID")
                    .IsUnique();

                entity.HasIndex(e => e.Subject)
                    .HasName("Subject");

                entity.HasIndex(e => new { e.Number, e.Subject })
                    .HasName("Number")
                    .IsUnique();

                entity.Property(e => e.CatalogId)
                    .HasColumnName("CatalogID")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnType("char(4)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Subject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Courses_ibfk_1");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.Subject)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Subject)
                    .HasName("Subject")
                    .IsUnique();

                entity.Property(e => e.Subject).HasColumnType("varchar(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<EnrollmentGrade>(entity =>
            {
                entity.HasKey(e => new { e.UId, e.CId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CId)
                    .HasName("cID");

                entity.HasIndex(e => e.UId)
                    .HasName("uID")
                    .IsUnique();

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.CId)
                    .HasColumnName("cID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Grade).HasColumnType("varchar(2)");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.EnrollmentGrade)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EnrollmentGrade_ibfk_2");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.EnrollmentGrade)
                    .HasForeignKey<EnrollmentGrade>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EnrollmentGrade_ibfk_1");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Subject)
                    .HasName("Subject");

                entity.HasIndex(e => e.UId)
                    .HasName("uID")
                    .IsUnique();

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Professor)
                    .HasForeignKey(d => d.Subject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Professor_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Professor)
                    .HasForeignKey<Professor>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Professor_ibfk_2");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Subject)
                    .HasName("Subject");

                entity.HasIndex(e => e.UId)
                    .HasName("uID")
                    .IsUnique();

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Subject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Students_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Students)
                    .HasForeignKey<Students>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Students_ibfk_2");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.HasKey(e => new { e.AId, e.UId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UId)
                    .HasName("uID");

                entity.Property(e => e.AId)
                    .HasColumnName("aID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Contents).HasColumnType("varchar(8192)");

                entity.Property(e => e.Score).HasColumnType("int(11)");

                entity.Property(e => e.Time)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.AId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Submission_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Submission_ibfk_2");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UId)
                    .HasName("uID")
                    .IsUnique();

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("fName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasColumnName("lName")
                    .HasColumnType("varchar(100)");
            });
        }
    }
}
