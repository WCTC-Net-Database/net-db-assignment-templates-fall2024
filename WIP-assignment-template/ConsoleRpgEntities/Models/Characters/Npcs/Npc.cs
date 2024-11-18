using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Characters.Npcs
{
    public abstract class Npc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NpcType { get; set; }

        protected Npc()
        {
            // Maybe could instantiate some Items to sell?
        }

        public abstract void Talk(ICharacter character);
        public virtual void Trade(ICharacter character)
        {
            Console.WriteLine($"{Name} trades with you.");
        }
    }
}
