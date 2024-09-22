using W7_assignment_template.Interfaces;

namespace W7_assignment_template.Models.Characters;

public class Ghost : CharacterBase, IFlyable
{
    public Ghost(string name, IRoom startingRoom) : base(name, startingRoom)
    {
    }

    public void Fly()
    {
        Console.WriteLine($"{Name} flies rapidly through the air.");
    }

    public override void UniqueBehavior()
    {
        throw new NotImplementedException();
    }
}
