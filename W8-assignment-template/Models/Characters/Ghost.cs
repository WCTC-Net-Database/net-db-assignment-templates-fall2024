using W8_assignment_template.Interfaces;
using W8_assignment_template.Services;

namespace W8_assignment_template.Models.Characters;

public class Ghost : CharacterBase, IFlyable
{
    public Ghost(string name, IRoom startingRoom, OutputManager outputManager)
        : base(name, startingRoom, outputManager)
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
