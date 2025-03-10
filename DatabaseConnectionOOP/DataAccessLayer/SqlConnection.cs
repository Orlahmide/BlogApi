namespace DataAccessLayer
{
    public class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionString) : base(connectionString) { }

        public override void Open()
        {
            Console.WriteLine("Opening SQL Server connection...");
        }

        public override void Close()
        {
            Console.WriteLine("Closing SQL Server connection...");
        }
    }
}

