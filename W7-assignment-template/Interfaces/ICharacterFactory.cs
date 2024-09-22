namespace W7_assignment_template.Interfaces;

public interface ICharacterFactory
{
    ICharacter CreateCharacter(string characterType, string name, IRoom startingRoom);
}
