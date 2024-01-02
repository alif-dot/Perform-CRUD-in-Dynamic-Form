using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudApi.Models
{
    public partial class projectstestdbContext : DbContext
    {
        public projectstestdbContext()
        {
        }

        public projectstestdbContext(DbContextOptions<projectstestdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountHolderTable> AccountHolderTables { get; set; } = null!;
        public virtual DbSet<NomineeTable> NomineeTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ALIF\\SQLEXPRESS01;Database=projectstestdb;User ID=sa;Password=S123456_;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountHolderTable>(entity =>
            {
                entity.HasKey(e => e.AccountholderId)
                    .HasName("PK__AccountH__DDBD376A8A321522");

                entity.ToTable("AccountHolderTable");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountholderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<NomineeTable>(entity =>
            {
                entity.HasKey(e => e.NomineeId)
                    .HasName("PK__NomineeT__40B5EA16755C1539");

                entity.ToTable("NomineeTable");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.NomineeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountHolder)
                    .WithMany(p => p.NomineeTables)
                    .HasForeignKey(d => d.AccountHolderId)
                    .HasConstraintName("FK__NomineeTa__Accou__4D94879B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
