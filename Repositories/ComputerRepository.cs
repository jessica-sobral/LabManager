using LabManger.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class ComputerRepository
{
    public List<Computer> GetAll()
    {
        var computers = new List<Computer>();

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers";

        var reader = command.ExecuteReader();
        
        while(reader.Read())
        {
            var id = reader.GetInt32(0);
            var ram = reader.GetString(1);
            var processor = reader.GetString(2);

            var computer = new Computer(id, ram, processor);
            // var computer = new Computer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            
            computers.Add(computer);

            // computer.Add(
            //     new Computer(
            //         reader.GetInt32(0),
            //         reader.GetString(1),
            //         reader.GetString(2)
            //     )
            // );
        }
        
        connection.Close();
        
        return computers;
    }
}