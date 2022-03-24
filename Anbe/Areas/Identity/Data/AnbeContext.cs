using Anbe.Areas.AnbeAdmin.Models;
using Anbe.Areas.Identity.Data;
using Anbe.Mapping;
using Anbe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalR.Bugeto.Models.Entities;

namespace Anbe.Data
{
    public class AnbeContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AnbeContext(DbContextOptions<AnbeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new Product_CategoryMap());



            builder.Entity<ApplicationUserRole>()
                .HasOne(userRole => userRole.Role)
                .WithMany(role => role.Users).HasForeignKey(r => r.RoleId);



            builder.Entity<ApplicationUserRole>()
               .HasOne(userRole => userRole.User)
               .WithMany(role => role.Roles).HasForeignKey(r => r.UserId);


            builder.Entity<JadvaleVaset>().HasKey(t => new { t.UserId, t.DastebandiKolliId });



            builder.Entity<JadvaleVaset>()
                .HasOne<DastebandiKolli>(sc => sc.DastebandiKolliee)
                .WithMany(s => s.Users)
                .HasForeignKey(sc => sc.DastebandiKolliId).IsRequired();


            builder.Entity<JadvaleVaset>()
                .HasOne<ApplicationUser>(sc => sc.Useree)
                .WithMany(s => s.DastebandiKollis)
                .HasForeignKey(sc => sc.UserId).IsRequired();

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        #region Wallet
        public DbSet<Wallet> wallets { set; get; }
        public DbSet<WalleTType> walleTTypes { set; get; }
        #endregion
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product_Category> Product_Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }

        public DbSet<Color> Color { get; set; }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<JadvaleVaset> JadvaleVasets { get; set; }
        public DbSet<DastebandiKolli> DastebandiKollis { get; set; }
        public DbSet<ChatRoom> ChatRooms{ get; set; }
        public DbSet<ChatMessage> ChatMessages{ get; set; }
    }
}
