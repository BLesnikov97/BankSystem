using BankSystem.BusinesLogic.Model;
using BankSystem.BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Account> Account { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={_connectionConfig.Host};Port={_connectionConfig.Port};" +
                $"Database={_connectionConfig.Database};Username={_connectionConfig.UserName};Password={_connectionConfig.Password}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("UserAccaunts");
            base.OnModelCreating(modelBuilder);
        }
    }


}

