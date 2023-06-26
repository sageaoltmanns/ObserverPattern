using ObserverPattern.Models;

namespace ObserverPattern.DataAccess;

public interface ILunchDataAccess
{
    public bool AddInternToLunch(int lunchId, Intern intern);
    public Lunch GetLunchById(int id);
    public bool RemoveInternFromLunch(int lunchId, Intern intern);
    public bool UpdateLeader(string newLeader, Lunch lunch);
    public bool UpdateSubject(string topic, Lunch lunch);
}

public class LunchDataAccess : ILunchDataAccess
{
    private readonly Database _data;

    public LunchDataAccess(Database data)
    {
        _data = data;
    }

    public bool AddInternToLunch(int lunchId, Intern intern)
    {
        var lunch = GetLunchById(lunchId);

        if (lunch == null)
            return false;

        var lunchToUpdate = _data.Lunches.Where(x => x.Id == lunchId).Select(x => x.Interns).FirstOrDefault();
        
        lunchToUpdate.Add(intern);
        
        return true;
    }

    public bool RemoveInternFromLunch(int lunchId, Intern intern)
    {
        var lunch = GetLunchById(lunchId);

        if (lunch == null)
            return false;

        lunch.Interns.Remove(intern);

        return true;
    }

    public bool UpdateLeader(string newLeader, Lunch lunch)
    {
        var lunchToUpdate = GetLunchById(lunch.Id);

        if (lunchToUpdate == null)
            return false;

        lunchToUpdate.Leader = newLeader;

        return true;
    }

    public bool UpdateSubject(string topic, Lunch lunch)
    {
        var lunchToUpdate = GetLunchById(lunch.Id);

        if (lunchToUpdate == null)
            return false;

        lunchToUpdate.Topic = topic;

        return true;
    }

    public Lunch GetLunchById(int id)
    {
        return _data.Lunches.FirstOrDefault(x => x.Id == id);
    }
}
