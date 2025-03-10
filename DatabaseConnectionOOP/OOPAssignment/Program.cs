using DataAccessLayer;

namespace OOPAssigment
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("\nUsing SQL Server:");
                DbConnection sqlConnectionOne = new SqlConnection("Server=myServer;Database=myDB;User Id=tomilola;Password=jicklewkle;");
                sqlConnectionOne.OpenWithTimeout();
                sqlConnectionOne.Close();
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            try
            {
                Console.WriteLine("\nUsing Oracle Server:");
                DbConnection oracleConnectionOne = new OracleConnection("Data Source=myOracleDB;User Id=frances;Password=tomilola;");
                oracleConnectionOne.OpenWithTimeout();
                oracleConnectionOne.Close();
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n\n\nExecuting task...");
            Console.WriteLine("\nUsing SQL Server:");
            var sqlConnection = new SqlConnection("Server=myServer;Database=myDB;User Id=tomilola;Password=uiiojfpkqw[;");
            var sqlCommand = new DbCommand(sqlConnection, "SELECT * FROM Users");
            sqlCommand.Execute();

            Console.WriteLine("\nUsing OracleServer:");
            var oracleConnection = new OracleConnection("OData Source=myOracleDB;User Id=frances;Password=tomilola;");
            var oracleCommand = new DbCommand(oracleConnection, "SELECT * FROM Employees");
            oracleCommand.Execute();
        }
    }
}