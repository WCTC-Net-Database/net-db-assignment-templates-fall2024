using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Abilities.MonsterAbilities
{
    public abstract class MonsterAbility : IAbility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MonsterAbilityType { get; set; }

        public virtual IEnumerable<ICharacter> Monsters { get; set; }

        protected MonsterAbility()
        {
            Monsters = new List<ICharacter>();
        }

        // Explicit interface implementation to map the generic property to the specific property
        IEnumerable<ICharacter> IAbility.Characters
        {
            get => Monsters;
            set => Monsters = value;
        }

        public abstract void Activate(ICharacter user, ITargetable target);
    }
}
