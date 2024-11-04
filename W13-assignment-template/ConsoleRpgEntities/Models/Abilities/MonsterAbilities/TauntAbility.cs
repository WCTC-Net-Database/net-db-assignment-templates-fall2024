using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Abilities.MonsterAbilities
{
    public class TauntAbility : MonsterAbility
    {
        public int TauntDuration { get; set; }

        public override void Activate(ICharacter user, ITargetable target)
        {
            // Taunt ability logic
            Console.WriteLine($"{user.Name} taunts {target.Name} for {TauntDuration} seconds!");
        }
    }
}
