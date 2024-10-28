namespace ConsoleRpgEntities.Models.Characters.Abilities;

public interface IAbility
{
    int Id { get; set; }
    string Name { get; set; }

    void Activate(ICharacter user, ICharacter target);
}