using BankSystem.BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BankSystem.DataAccess.BaseConnect
{
    public class ApplicationContext : DbContext
    {
        private ConnectionConfig _connectionConfig;

        public ApplicationContext(ConnectionConfig config)
        {
            _connectionConfig = config;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={_connectionConfig.Host};Port={_connectionConfig.Port};" +
                $"Database={_connectionConfig.Database};Username={_connectionConfig.UserName};Password={_connectionConfig.Password}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasMany(a => a.UserId).WithRequired(a => a.UserId);

            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("Id");
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnName("FullName");

            modelBuilder.Entity<Account>().Property(u => u.Amount).HasColumnName("Cash");

            modelBuilder.Entity<User>().Property(u => u.Id).HasMaxLength(5);
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasMaxLength(150);
            modelBuilder.Entity<User>().Property(u => u.LastName).HasMaxLength(150);
            modelBuilder.Entity<User>().Property(u => u.MiddleName).HasMaxLength(150);

            modelBuilder.Entity<Account>().Property(a => a.Description).HasMaxLength(150);
            modelBuilder.Entity<Account>().Property(a => a.Amount).HasPrecision(15, 2);
            modelBuilder.Entity<Account>().Property(a => a.Currency).HasMaxLength(150);
        }
    }


}

