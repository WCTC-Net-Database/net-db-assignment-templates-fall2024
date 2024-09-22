using W8_assignment_template.Interfaces;
using W8_assignment_template.Services;

namespace W8_assignment_template.Models.Characters
{
    public class Player : CharacterBase
    {
        public Player(string name, IRoom startingRoom, OutputManager outputManager)
            : base(name, startingRoom, outputManager)
        {
        }

        public override void UniqueBehavior()
        {
            // Implement unique behavior for the player
        }
    }
}
