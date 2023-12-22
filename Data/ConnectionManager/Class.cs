namespace WebAppCZN.Data.ConnectionManager
{
    public class ConnectionStringManager
    {
        private string _connectionString;

        public ConnectionStringManager(string defaultConnectionString)
        {
            _connectionString = defaultConnectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public void SetConnectionString(string newConnectionString)
        {
            _connectionString = newConnectionString;
        }
    }
}
