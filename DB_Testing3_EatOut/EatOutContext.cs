using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Testing3_EatOut.Interfaces;

namespace DB_Testing3_EatOut
{
    class EatOutContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Seat> Seats { get; set; }


        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<EmployeeForm> EmployeeForms { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }



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
           
            return base.SaveChanges();
        }

    }
}
