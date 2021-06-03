using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UsedCars.Core.Entities;

#nullable disable

namespace UsedCars.Core
{
    public partial class UsedCarsContext : DbContext
    {
        public UsedCarsContext()
        {
        }

        public UsedCarsContext(DbContextOptions<UsedCarsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvKeboardProgram> AvKeboardPrograms { get; set; }
        public virtual DbSet<KeyboardProgram> KeyboardPrograms { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AvKeboardProgram>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("av_KeboardPrograms");

                entity.Property(e => e.KorgProgram).HasMaxLength(200);

                entity.Property(e => e.NordProgram).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<KeyboardProgram>(entity =>
            {
                entity.Property(e => e.KorgProgram).HasMaxLength(200);

                entity.Property(e => e.NordProgram).HasMaxLength(200);

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.KeyboardPrograms)
                    .HasForeignKey(d => d.SongId)
                    .HasConstraintName("FK_KeyboardPrograms_Songs");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
