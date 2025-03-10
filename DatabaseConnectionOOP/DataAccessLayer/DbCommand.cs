using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbCommand
    {
        private readonly DbConnection _connection;
        private readonly string _instruction;

        public DbCommand(DbConnection connection, string instruction)
        {
            _connection = connection ?? throw new InvalidOperationException("DbConnection cannot be null.");
            _instruction = !string.IsNullOrWhiteSpace(instruction)
                ? instruction
                : throw new InvalidOperationException("Instruction cannot be null or empty.");
        }

        public void Execute()
        {
            _connection.Open();
            Console.WriteLine($"Executing instruction: {_instruction}");
            _connection.Close();
        }
    }
}
