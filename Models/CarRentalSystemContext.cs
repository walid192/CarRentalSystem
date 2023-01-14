using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System.Models;

public partial class CarRentalSystemContext : DbContext
{
    private static CarRentalSystemContext instance;
    private CarRentalSystemContext()
    {
    }


    public static CarRentalSystemContext Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CarRentalSystemContext();
            }
            return instance;
        }
    }

    public CarRentalSystemContext(DbContextOptions<CarRentalSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Rent> Rents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-0N4UGJ4;Database=CarRentalSystem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_history");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.CarNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CAR_NUMBER");
            entity.Property(e => e.Engine)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENGINE");
            entity.Property(e => e.FuelType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FUEL_TYPE");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(155)
                .IsUnicode(false)
                .HasColumnName("IMAGE_Path");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.PassingYear).HasColumnName("PASSING_YEAR");
            entity.Property(e => e.SeatingCapacity).HasColumnName("SEATING_CAPACITY");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.DriverName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DRIVER_NAME");
            entity.Property(e => e.Experience).HasColumnName("EXPERIENCE");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("IMAGE_PATH");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MOBILE_NUMBER");
        });

        modelBuilder.Entity<Rent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Rents");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.CustomerContactNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_CONTACT_NO");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_NAME");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.DropOff)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DROP_OFF");
            entity.Property(e => e.DropOffDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DROP_OFF_DATE");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.PickUp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PICK_UP");
            entity.Property(e => e.PickUpDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PICK_UP_DATE");
            entity.Property(e => e.Rate).HasColumnName("RATE");
            entity.Property(e => e.TotalAmount).HasColumnName("TOTAL_AMOUNT");
            entity.Property(e => e.TotalRun).HasColumnName("TOTAL_RUN");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
