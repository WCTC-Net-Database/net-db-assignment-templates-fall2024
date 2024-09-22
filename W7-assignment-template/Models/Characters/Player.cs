using W7_assignment_template.Interfaces;

namespace W7_assignment_template.Models.Characters;

public class Player : CharacterBase
{
    public Player(string name, IRoom startingRoom) : base(name, startingRoom)
    {
    }

    public override void UniqueBehavior()
    {
        throw new NotImplementedException();
    }
}
