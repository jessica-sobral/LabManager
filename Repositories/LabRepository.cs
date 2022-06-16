using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class LabRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public LabRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Lab> GetAll()
    {
        var labs = new List<Lab>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Lab";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var lab = new Lab(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));

            labs.Add(lab);
        }

        connection.Close(); 

        return labs;
    }

    public Lab Save(Lab lab)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Lab VALUES($id, $number, $name, $block)";
        command.Parameters.AddWithValue("$id", lab.Id);
        command.Parameters.AddWithValue("$number", lab.Number);
        command.Parameters.AddWithValue("$name", lab.Name);
        command.Parameters.AddWithValue("$block", lab.Block);

        command.ExecuteNonQuery();
        connection.Close();

        return lab;
    }

    public void Delete(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Lab WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", id);

        command.ExecuteNonQuery();
        connection.Close();
    }
}