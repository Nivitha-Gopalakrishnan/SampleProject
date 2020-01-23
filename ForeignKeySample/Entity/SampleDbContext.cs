using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ForeignKeySample.Entity
{
    public partial class SampleDbContext : DbContext
    {
        public SampleDbContext()
        {
        }

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<StudentBookMapper> StudentBookMapper { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsPersonalDetails> StudentsPersonalDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentBookMapper>(entity =>
            {
                entity.Property(e => e.IsPgstudent).HasColumnName("IsPGStudent");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.StudentBookMapper)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentBookMapper_BookId");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.Country)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentsPersonalDetails>(entity =>
            {
                entity.Property(e => e.Department)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StudentsPersonalDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsPersonalDetails_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
