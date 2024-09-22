using W7_assignment_template.Interfaces;

namespace W7_assignment_template.Models.Characters;

public class CharacterFactory : ICharacterFactory
{
    public ICharacter CreateCharacter(string characterType, string name, IRoom startingRoom)
    {
        switch (characterType.ToLower())
        {
            case "player":
                return new Player(name, startingRoom);
            case "goblin":
                return new Goblin(name, startingRoom);
            case "ghost":
                return new Ghost(name, startingRoom);
            default:
                throw new ArgumentException("Invalid character type", nameof(characterType));
        }
    }
}
