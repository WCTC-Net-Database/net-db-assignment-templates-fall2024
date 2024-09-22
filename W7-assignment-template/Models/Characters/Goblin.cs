using W7_assignment_template.Interfaces;

namespace W7_assignment_template.Models.Characters;

public class Goblin : CharacterBase
{
    public Goblin(string name, IRoom startingRoom) : base(name, startingRoom)
    {
    }

    public override void UniqueBehavior()
    {
        throw new NotImplementedException();
    }
}
