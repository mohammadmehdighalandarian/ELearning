using DataLayer.Entities.User;
using DataLayer.Entities.Wallet;
using DataLayer.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Content
{
    public class SiteContext:DbContext
    {


        #region User

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Wallet

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }

        #endregion


        public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserMapping());
            //modelBuilder.ApplyConfiguration(new UserRoleMapping());
            //modelBuilder.ApplyConfiguration(new RoleMapping());
            //modelBuilder.ApplyConfiguration(new WalletMapping());
            //modelBuilder.ApplyConfiguration(new WalletTypeMapping());
            modelBuilder.Entity<User>().HasQueryFilter(u => u.Isdeleted==false);
            modelBuilder.Entity<Role>().HasQueryFilter(x => x.IsDeleted==false);

            var assembly=typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            

        }
    }
}
