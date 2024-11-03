using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Data;

public interface IContext
{
    // READ
    List<CharacterBase> Characters { get; set; }

    // CREATE
    void AddCharacter(CharacterBase character);

    // DELETE
    void DeleteCharacter(string characterName);

    // UPDATE
    void UpdateCharacter(CharacterBase character);
}
