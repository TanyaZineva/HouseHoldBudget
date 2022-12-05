using HouseHoldBudget.Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace HouseHoldBudget.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext <User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BudgetInitial> BudgetInitials { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<TypeOfAccount> TypeOfAccounts { get; set; } = null!;
        public DbSet<HouseHold> HouseHolds { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserBudgetInitial>()
                .HasKey(x => new { x.UserId, x.BudgetInitialId });

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CurrencyConfiguration());
            builder.ApplyConfiguration(new TypeOfAccountConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }

    }
}