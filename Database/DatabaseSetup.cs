using Microsoft.Data.Sqlite;

namespace LabManager.Database;

class DatabaseSetup
{
    private readonly DatabaseConfig _databaseConfig;
    
    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CreateComputerTable();
        CreateLabTable();
    }

    private void CreateComputerTable()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Computers(
                id int not null primary key,
                ram varchar(100) not null,
                processor varchar(100) not null
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
    }


    private void CreateLabTable()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Lab(
                id int not null primary key,
                number int not null,
                name varchar(100) not null,
                block varchar(100) not null
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
    }
}
