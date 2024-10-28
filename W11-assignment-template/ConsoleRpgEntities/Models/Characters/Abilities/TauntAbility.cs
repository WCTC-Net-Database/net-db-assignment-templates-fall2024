namespace ConsoleRpgEntities.Models.Characters.Abilities
{
    public class TauntAbility : Ability
    {
        public int TauntDuration { get; set; }

        public override void Activate(ICharacter user, ICharacter target)
        {
            // Taunt ability logic
            Console.WriteLine($"{user.Name} taunts {target.Name} for {TauntDuration} seconds!");
        }
    }
}
