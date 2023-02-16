using BankSystem.BusinesLogic.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;

namespace BankSystem.DataAccess.BaseConnect
{
    public class ApplicationContext : DbContext
    {
        private ConnectionConfig _connectionConfig;

        public ApplicationContext(ConnectionConfig config)
        {
            _connectionConfig = config;
        }

        public DbSet<UserAccount> UserAccaunts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={_connectionConfig.Host};Port={_connectionConfig.Port};" +
                $"Database={_connectionConfig.Database};Username={_connectionConfig.UserName};Password={_connectionConfig.Password}");

        }
    }


}

