using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RecepcjaHotel.Models;

#nullable disable

namespace RecepcjaHotel.Models
{
    public partial class RecepcjaDBContext : DbContext
    {
        public RecepcjaDBContext()
        {
        }

        public RecepcjaDBContext(DbContextOptions<RecepcjaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomsType> RoomsTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-O3PUJRAM;Database=RecepcjaDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ClientsId).HasColumnName("ClientsID");

                entity.Property(e => e.DateCheckIn)
                    .HasColumnType("date")
                    .HasColumnName("Date_CheckIn");

                entity.Property(e => e.DateCheckOut)
                    .HasColumnType("date")
                    .HasColumnName("Date_CheckOut");

                entity.Property(e => e.PaymentsId).HasColumnName("PaymentsID");

                entity.Property(e => e.RoomsId).HasColumnName("RoomsID");

                entity.HasOne(d => d.Clients)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ClientsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Clients");

                entity.HasOne(d => d.Payments)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.PaymentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Payments");

                entity.HasOne(d => d.Rooms)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RoomsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Rooms");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoomsTypeId).HasColumnName("RoomsTypeID");

                entity.HasOne(d => d.RoomsType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomsTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_RoomsType");
            });

            modelBuilder.Entity<RoomsType>(entity =>
            {
                entity.ToTable("RoomsType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Size).HasColumnType("decimal(5, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<RecepcjaHotel.Models.Forbidden> Forbidden { get; set; }
    }
}
