using W8_assignment_template.Interfaces;
using W8_assignment_template.Services;

namespace W8_assignment_template.Models.Characters;

public class CharacterFactory : ICharacterFactory
{
    public ICharacter CreateCharacter(string characterType, string name, IRoom startingRoom, OutputManager outputManager)
    {
        switch (characterType.ToLower())
        {
            case "player":
                return new Player(name, startingRoom, outputManager);
            case "goblin":
                return new Goblin(name, startingRoom, outputManager);
            case "ghost":
                return new Ghost(name, startingRoom, outputManager);
            default:
                throw new ArgumentException("Invalid character type", nameof(characterType));
        }
    }
}
