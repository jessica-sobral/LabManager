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
dotnet run -- Lab Update 1 '8' 'Charles ...' '2'
dotnet run -- Lab Show 1

foreach (var arg in args)
{
    Console.WriteLine(arg);
}

dotnet add package Microsoft.Data.Sqlite
dotnet add package Microsoft.Data.Sqlite -s 'C:\Users\IFSP\.nuget\packages'
*/

using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();

var databaseSetup = new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);
var labRepository = new LabRepository(databaseConfig);

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
        foreach (var lab in labRepository.GetAll())
        {
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
    }

    if(modelAction == "New")
    {
        // Console.WriteLine("Lab New");
        var id = Convert.ToInt32(args[2]);
        string number = args[3];
        string name = args[4];
        string block = args[5];

        var lab = new Lab(id, number, name, block);

        labRepository.Save(lab);
    }

    if(modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExitsById(id))
        {
            var lab = labRepository.GetById(id);
            
            Console.WriteLine("{0}, {1}, {2}, {3}", lab.Id, lab.Number, lab.Name, lab.Block);
        } else {
            Console.WriteLine($"O laboratório com ID {id} não existe.");
        }
    }

    if(modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);
        string number = args[3];
        string name = args[4];
        string block = args[5];

        var lab = new Lab(id, number, name, block);

        labRepository.Update(lab);
    }

    if(modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);
        labRepository.Delete(id);
    }
}