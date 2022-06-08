﻿/*
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
using LabManager.Repositories;
using LabManger.Models;

var databaseConfig = new DatabaseConfig();

var databaseSetup = new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);

// Routing
var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
    }

    if(modelAction == "New")
    {
        // Console.WriteLine("Computer New");
        // Console.WriteLine("{0}, {1}, {2}", id, ram, processor);

        var id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];

        var computer = new Computer(id, ram, processor);

        computerRepository.Save(computer);
    }

    if(modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExitsById(id))
        {
            var computer = computerRepository.GetById(id);
            
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        } else {
            Console.WriteLine($"O computador com ID {id} não existe.");
        }
    }

    if(modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];

        var computer = new Computer(id, ram, processor);

        computerRepository.Update(computer);
    }

    if(modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);
        computerRepository.Delete(id);
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
            Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetInt32(1)}, {reader.GetString(2)}, {reader.GetString(3)}");
        }
        
        connection.Close();
    }

    if(modelAction == "New")
    {
        // Console.WriteLine("Lab New");
        var id = Convert.ToInt32(args[2]);
        var number = Convert.ToInt32(args[3]);
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