using W8_assignment_template.Interfaces;
using W8_assignment_template.Services;

namespace W8_assignment_template.Models.Characters;

public class Goblin : CharacterBase
{
    public Goblin(string name, IRoom startingRoom, OutputManager outputManager)
        : base(name, startingRoom, outputManager)
    {
    }

    public override void UniqueBehavior()
    {
        throw new NotImplementedException();
    }
}
