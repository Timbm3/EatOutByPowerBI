using EatOutByBI.Data.Classes;
using EatOutByBI.Data.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace EatOutByBI.Data
{
    public class EatOutContext : DbContext
    {

        public EatOutContext() : base("EatOutByBI.Domain4")
        {
            Database.SetInitializer<EatOutContext>(new CreateDatabaseIfNotExists<EatOutContext>());
        }



        public DbSet<SalesOrder> SalesOrders { get; set; }

        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Seat> Seats { get; set; }


        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<EmployeeForm> EmployeeForms { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }


        public DbSet<TimeTable> TimeTables { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingTime> BookingTimes { get; set; }
        public DbSet<Booked> Bookeds { get; set; }



        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<EmployeeEvent> EmployeeEvents { get; set; }
        public DbSet<EmployeeEventType> EmployeeEventTypes { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Booked>()
        //        .Property(x => x.BookedId)
        //        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        //}

        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries()
                .Where(
                    e =>
                        e.Entity is IModificationHistory &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationHistory))
            {
                history.DateModified = DateTime.Now;
                if (history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }

            }

            int result = base.SaveChanges();
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory)
                .Select(e => e.Entity as IModificationHistory)
                )
            {
                history.DateModified = DateTime.Now;
            }
            return result;
        }

    }
}
