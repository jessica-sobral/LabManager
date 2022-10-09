using LabManager.Models;

namespace LabManager.Repositories;

class ComputerRepository
{
    SystemContext context = new SystemContext();

    public ComputerRepository(SystemContext systemContext)
    {
        this.context = systemContext;
    }

    public IEnumerable<Computer> GetAll()
    {
        return context.Computers;
    }

    public Computer Add(Computer computer)
    {
        context.Computers.Add(computer);
        context.SaveChanges();

        return computer;
    }

    public Computer GetById(int id)
    {
        return context.Computers.Find(id);
    }

    public Computer Update(Computer computer)
    {
        context.Computers.Update(computer);
        context.SaveChanges();

        return computer;
    }

    public void Delete(int id)
    {
        context.Computers.Remove(GetById(id));
        context.SaveChanges();
    }

    public bool ExistsById(int id)
    {
        if(context.Computers.Contains(GetById(id)))
        {
            return true;
        }
        
        return false;
    }
}
