using BankSystem.BusinesLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Client.WPF.Util
{
    public class ConnectionConfig
    {
        public ConnectionConfig() 
        {
        
        }

        private string _host = "localhost";
        private string _port = "5432";
        private string _database = "WPF";
        private string _username = "postgres";
        private string _password = "1234";

        public string Host { get { return _host; } }
        public string Port { get { return _port; } }
        public string Database { get { return _database; } }
        public string UserName { get { return _username; } }
        public string Password { get { return _password; } }

    }
}
