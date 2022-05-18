/*
CRUD (CREATE, READ, UPDATE, DELETE)

Computer - Id, Ram, Processor

dotnet run -- Computer List
dotnet run -- Computer New 1 '16' 'Intel Dual Core'
dotnet run -- Computer Delete 1
dotnet run -- Computer Update 1 '8' 'Intel Dual Core'
dotnet run -- Computer Show 1

Lab - Id, Number, Name, Block

dotnet run -- Lab List
dotnet run -- Lab New 1 '2' 'Charles ...' '2'
dotnet run -- Lab Delete 1
dotnet run -- Lab Update 1 '2' 'Charles ...' '2'
dotnet run -- Lab Show 1

foreach (var arg in args)
{
    Console.WriteLine(arg);
}

dotnet add package Microsoft.Data.Sqlite
dotnet add package Microsoft.Data.Sqlite -s 'C:\Users\IFSP\.nuget\packages'

*/

using Microsoft.Data.Sqlite;
using LabManager.Database;

var databaseSetup = new DatabaseSetup();

// Routing
var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers";

        var reader = command.ExecuteReader();
        
        while(reader.Read())
        {
            Console.WriteLine("{0}, {1}, {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
        }
        
        connection.Close();
    }

    if(modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];
        //Console.WriteLine("Computer New");
        //Console.WriteLine("{0}, {1}, {2}", id, ram, processor);

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processor", processor);

        command.ExecuteNonQuery();
        connection.Close();
    }
}

if(modelName == "Lab")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Lab List");
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Lab";

        var reader = command.ExecuteReader();
        
        while(reader.Read())
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));
        }
        
        connection.Close();
    }

    if(modelAction == "New")
    {
        // Console.WriteLine("Lab New");
        var id = Convert.ToInt32(args[2]);
        var number = args[3];
        string name = args[4];
        string block = args[5];

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Lab VALUES($id, $number, $name, $block)";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$number", number);
        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$block", block);

        command.ExecuteNonQuery();
        connection.Close();
    }
}