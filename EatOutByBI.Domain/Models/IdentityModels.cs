using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EatOutByBI.Domain.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        internal readonly object UserManager;

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>()
        //        .HasRequired(a => a.ProductGroupID)
        //        .WithMany(g => g.Attendences)
        //        .WillCascadeOnDelete(false);



        //    modelBuilder.Entity<ApplicationUser>()
        //        .HasMany(u => u.Followers)
        //        .WithRequired(u => u.Followee)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<ApplicationUser>()
        //        .HasMany(u => u.Followees)
        //        .WithRequired(u => u.Follower)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<UserNotification>()
        //        .HasRequired(n => n.User)
        //        .WithMany(u => u.UserNotifications)
        //        .WillCascadeOnDelete(false);


        //    base.OnModelCreating(modelBuilder);
        //}



        //public System.Data.Entity.DbSet<EatOutByBI.Domain.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<EatOutByBI.Domain.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}