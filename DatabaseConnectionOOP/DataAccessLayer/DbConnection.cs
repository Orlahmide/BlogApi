namespace DataAccessLayer
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; }
        public TimeSpan Timeout { get; set; }

        protected DbConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));
            }

            ConnectionString = connectionString;
            Timeout = TimeSpan.FromSeconds(30); 
        }
        public void OpenWithTimeout()
        {
            Console.WriteLine("Attempting to open connection...");

            var startTime = DateTime.Now;

            // Simulating connection attempt
            Thread.Sleep(5000); // Simulating 2 seconds delay

            var elapsed = DateTime.Now - startTime;
            if (elapsed > Timeout)
            {
                throw new TimeoutException("Connection timed out.");
            }

            Open();
        }

        public abstract void Open();
        public abstract void Close();
    }
}
