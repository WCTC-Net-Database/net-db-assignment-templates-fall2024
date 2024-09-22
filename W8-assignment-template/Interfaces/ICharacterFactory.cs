using W8_assignment_template.Interfaces;
using W8_assignment_template.Services;

public interface ICharacterFactory
{
    ICharacter CreateCharacter(string characterType, string name, IRoom startingRoom, OutputManager outputManager);
}
