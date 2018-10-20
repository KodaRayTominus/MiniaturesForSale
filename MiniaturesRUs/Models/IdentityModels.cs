using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace MiniaturesRUs.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Persons First and LastName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// A Persons Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Biography of the person
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// The persons favorite game to be displayed
        /// </summary>
        public string FavoriteGame { get; set; }

        /// <summary>
        /// The persons nickname to be displayed
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// A persons personal fan fiction for their fan faction
        /// </summary>
        public string FactionFanFiction { get; set; }

        /// <summary>
        /// details on a persons past experience with miniatures and gaming
        /// </summary>
        public string PastExperience { get; set; }

        /// <summary>
        /// List of different expertise
        /// </summary>
        public List<string> Expertise { get; set; }

        /// <summary>
        /// Miniatures that the person is interested in buying
        /// </summary>
        public List<int> WishList { get; set; }

        /// <summary>
        /// Miniatures the person wants to keep tabs on
        /// </summary>
        public List<int> WatchList { get; set; }

        /// <summary>
        /// miniatures the person owns
        /// </summary>
        public List<int> Owned { get; set; }

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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Miniature> Minitures { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<ProductOrder> ProductOrders { get; set; }

        public virtual DbSet<PersonalMessage> PersonalMessages { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}