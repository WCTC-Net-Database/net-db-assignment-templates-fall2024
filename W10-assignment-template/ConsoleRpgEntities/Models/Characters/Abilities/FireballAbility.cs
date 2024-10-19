namespace ConsoleRpgEntities.Models.Characters.Abilities
{
    public class FireballAbility : Ability
    {
        public int Damage { get; set; }
        public int Radius { get; set; }

        public override void Activate(ICharacter user, ICharacter target)
        {
            // Fireball ability logic
            Console.WriteLine($"{user.Name} casts Fireball at {target.Name}, dealing {Damage} damage!");
        }
    }
}
