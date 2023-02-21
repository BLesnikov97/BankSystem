using BankSystem.BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace BankSystem.DataAccess.BaseConnect
{
    public class FluentContext : System.Data.Entity.DbContext
    {
        private ConnectionConfig _connectionConfig;

        public FluentContext(ConnectionConfig config) : base("WPF")
        {
            _connectionConfig = config;
        }

        public System.Data.Entity.DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("UserAccaunts");
            base.OnModelCreating(modelBuilder);
        }
    }
}
