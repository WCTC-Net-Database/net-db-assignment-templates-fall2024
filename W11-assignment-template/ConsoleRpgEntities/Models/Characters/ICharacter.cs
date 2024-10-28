using ConsoleRpgEntities.Models.Characters.Abilities;

namespace ConsoleRpgEntities.Models.Characters;

public interface ICharacter
{
    int Id { get; set; }
    string Name { get; set; }
    ICollection<Ability> Abilities { get; set; }

    void Attack(ICharacter target);
    void UseAbility(Ability ability, ICharacter target);
}