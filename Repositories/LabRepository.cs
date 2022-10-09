using LabManager.Models;

namespace LabManager.Repositories;

class LabRepository
{
    SystemContext context = new SystemContext();

    public LabRepository(SystemContext systemContext)
    {
        this.context = systemContext;
    }

    public IEnumerable<Lab> GetAll()
    {
        return context.Labs;
    }

    public Lab Add(Lab lab)
    {
        context.Labs.Add(lab);
        context.SaveChanges();

        return lab;
    }

    public Lab GetById(int id)
    {
        return context.Labs.Find(id);
    }

    public Lab Update(Lab lab)
    {
        context.Labs.Update(lab);
        context.SaveChanges();

        return lab;
    }

    public void Delete(int id)
    {
        context.Labs.Remove(GetById(id));
    }

    public bool ExistsById(int id)
    {
        if(context.Labs.Contains(GetById(id)))
        {
            return true;
        }

        return false;
    }
}