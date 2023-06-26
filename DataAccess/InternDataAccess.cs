using ObserverPattern.Models;
using ObserverPattern;
using System.Xml.Linq;

namespace ObserverPattern.DataAccess;

public interface IInternDataAccess
{
    public void NotifyAboutUpdatedLeader(Lunch lunch);
    public void NotifyAboutUpdatedSubject(Lunch lunch);
    public Intern GetInternByName(string name);
}

public class InternDataAccess : IInternDataAccess
{
    private readonly Database _data;

    public InternDataAccess(Database data)
    {
        _data = data;
    }

    public void NotifyAboutUpdatedLeader(Lunch lunch)
    {
        foreach (var intern in lunch.Interns)
        {
            Console.WriteLine($"Hello {intern.Name}, the {lunch.Name} L&L's leader has changed to {lunch.Leader}.");
        }
    }

    public void NotifyAboutUpdatedSubject(Lunch lunch)
    {
        foreach (var intern in lunch.Interns)
        {
            Console.WriteLine($"Hello {intern.Name}, {lunch.Name} L&L's topic has been changed to {lunch.Topic}.");
        }
    }

    public Intern GetInternByName(string name)
    {
        return _data.Interns.Where(x => x.Name == name).FirstOrDefault();
    }
}
