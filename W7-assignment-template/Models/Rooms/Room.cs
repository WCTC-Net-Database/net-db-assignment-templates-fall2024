using W7_assignment_template.Interfaces;

namespace W7_assignment_template.Models.Rooms;

public class Room : IRoom
{
    public string Name { get; }
    public IRoom? North { get; set; }
    public IRoom? South { get; set; }
    public IRoom? West { get; set; }
    public IRoom? East { get; set; }
    public string Description { get; }

    public Room(string name, string description)
    {
        Name = name;
        Description = description;
    }
 
    public void Enter()
    {
        Console.WriteLine($"You have entered {Name}. {Description}");
    }

}
