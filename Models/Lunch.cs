namespace ObserverPattern.Models;
public class Lunch
{
    public Lunch (int id, string name, string leader, string topic)
    {
        Id = id;
        Name = name;
        Leader = leader;
        Topic = topic;
        Interns = new List<Intern>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Leader { get; set; }
    public string Topic { get; set; }
    public virtual List<Intern> Interns { get; set; }
}
