using Microsoft.EntityFrameworkCore;
using ObserverPattern.Models;

namespace ObserverPattern;

public class Database
{
    public Database()
    {
        Interns = new List<Intern>
        {
            new Intern(1, "Sage"),
            new Intern(2, "Carson"),
            new Intern(3, "Noah"),
            new Intern(4, "Gavin"),
            new Intern(5, "Jonah"),
            new Intern(6, "Gabe"),
            new Intern(7, "Mary"),
            new Intern(8, "Keiran"),
            new Intern(9, "Brooklyn"),
            new Intern(10, "Jackson"),
        };

        Lunches = new List<Lunch>()
        {
            new Lunch(1, "Series", "Ryan", "Design Patterns"),
            new Lunch(2, "Engineering", "Ale", "AI"),
            new Lunch(3, "Development", "John", "Dependency Injection"),
            new Lunch(4, "Book Club", "Michael", "Clean Code"),
            new Lunch(5, "Intern", "Noah, Carson, Sage", "Marvel Movie Marathon"),
        };
    }
    public List<Lunch> Lunches { get; set; }
    public List<Intern> Interns { get; set; }
}
