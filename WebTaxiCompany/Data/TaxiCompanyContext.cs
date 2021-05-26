using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebTaxiCompany.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebTaxiCompany.Data
{
    public partial class TaxiCompanyContext : DbContext
    {
        public TaxiCompanyContext()
        {
        }

        public TaxiCompanyContext(DbContextOptions<TaxiCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddService> AddService { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Call> Call { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlite("Data Source=C:\\Users\\Даша\\Source\\Repos\\WebTaxiCompany\\TaxiCompany.db");
                optionsBuilder.UseSqlServer("Data Source=SSMLNSK;Initial Catalog=TaxiCompany.db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddService>(entity =>
            {
                entity.HasKey(e => e.AddServiceKey);

                entity.Property(e => e.AddServiceKey)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("INT");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.BrandKey);

                entity.Property(e => e.BrandKey)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("INT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Specifications)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Specificity)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");
            });

            modelBuilder.Entity<Call>(entity =>
            {
                entity.HasKey(e => e.NumKey);

                entity.Property(e => e.NumKey).HasColumnType("INT");

                entity.Property(e => e.AddServiceKey).HasColumnType("INT");

                entity.Property(e => e.CarKey).HasColumnType("INT");

                entity.Property(e => e.Date).HasColumnType("DATE");

                entity.Property(e => e.EmployeeKey).HasColumnType("INT");

                entity.Property(e => e.Number).HasColumnType("INT");

                entity.Property(e => e.RateKey).HasColumnType("INT");

                entity.Property(e => e.Time).HasColumnType("DATETIME");

                entity.Property(e => e.WhereFrom).HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.WhereTo).HasColumnType("NVARCHAR (255)");

                entity.HasOne(d => d.AddServiceKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AddServiceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CarKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CarKey)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.EmployeeKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.RateKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarKey);

                entity.Property(e => e.CarKey)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.BodNumber).HasColumnType("INT");

                entity.Property(e => e.BrandKey).HasColumnType("INT");

                entity.Property(e => e.EmployeeKey).HasColumnType("INT");

                entity.Property(e => e.EngineNumber).HasColumnType("INT");

                entity.Property(e => e.MaintenanceDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.MechanicKeyEmployeeKey).HasColumnType("INT");

                entity.Property(e => e.Mileage).HasColumnType("INT");

                entity.Property(e => e.RegistrationNumber).HasColumnType("INT");

                entity.Property(e => e.SpecialMarks)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.YearOfIssue)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.HasOne(d => d.BrandKeyNavigation)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.BrandKey)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.EmployeeKeyNavigation)
                    .WithMany(p => p.CarEmployeeKeyNavigation)
                    .HasForeignKey(d => d.EmployeeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.MechanicKeyEmployeeKeyNavigation)
                    .WithMany(p => p.CarMechanicKeyEmployeeKeyNavigation)
                    .HasForeignKey(d => d.MechanicKeyEmployeeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeKey);

                entity.Property(e => e.EmployeeKey)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.DateOfBirth)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Number).HasColumnType("INT");

                entity.Property(e => e.Passport).HasColumnType("INT");

                entity.Property(e => e.PositionKey).HasColumnType("INT");

                entity.HasOne(d => d.PositionKeyNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionKey);

                entity.Property(e => e.PositionKey)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Requirement)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Responsibility)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Salary).HasColumnType("INT");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasKey(e => e.RateKey);

                entity.Property(e => e.RateKey)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("INT");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
