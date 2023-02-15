using BankSystem.BusinesLogic.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;

namespace BankSystem.DataAccess.BaseConnect
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        { 
            
        }

        //private NameValueCollection _config = ConfigurationManager.AppSettings;

        public DbSet<UserAccount> UserAccaunts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql($"Host={_config.Get("Host")};Port={_config.Get("Port")};Database={_config.Get("Database")};Username={_config.Get("Username")};Password={_config.Get("Password")}");
        //}
    }


}

