namespace ConsoleRpgEntities.Models.Characters.MonsterTypes
{
    public class Goblin : Monster
    {
        public int Sneakiness { get; set; }

        public override void Attack(ICharacter target)
        {
            // Goblin-specific attack logic
            Console.WriteLine($"{Name} sneaks up and attacks {target.Name}!");
        }
    }
}
