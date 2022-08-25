using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SecondHandCar.Models.DBModel
{
    public partial class CarSaleDb : DbContext
    {
        public CarSaleDb()
            : base("name=CarSaleDb5")
        {
        }

        public virtual DbSet<CarDetail> CarDetails { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDetail>()
                .Property(e => e.CarModel)
                .IsUnicode(false);

            modelBuilder.Entity<CarDetail>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CarDetail>()
                .Property(e => e.SaleLocation)
                .IsUnicode(false);

            modelBuilder.Entity<CarDetail>()
                .Property(e => e.CarColour)
                .IsUnicode(false);

            modelBuilder.Entity<UserTable>()
                .Property(e => e.CustFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<UserTable>()
                .Property(e => e.CustLastName)
                .IsUnicode(false);

            modelBuilder.Entity<UserTable>()
                .HasMany(e => e.CarDetails)
                .WithRequired(e => e.UserTable)
                .WillCascadeOnDelete(false);
        }
    }
}
