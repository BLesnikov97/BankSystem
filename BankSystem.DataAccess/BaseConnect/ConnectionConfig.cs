namespace BankSystem.DataAccess.BaseConnect
{
    public class ConnectionConfig
    {
        public ConnectionConfig() 
        {
        
        }

        public ConnectionConfig(string host, string port, string database, string userName, string password)
        {
            Host = host;
            Port = port;
            Database = database;
            UserName = userName;
            Password = password;
        }

        public string Host { get; private set; } = "localhost";
        public string Port { get; private set; } = "5432";
        public string Database { get; private set; } = "WPF";
        public string UserName { get; private set; } = "postgres";
        public string Password { get; private set; } = "1234";

    }
}
