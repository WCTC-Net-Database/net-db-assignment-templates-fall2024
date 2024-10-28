using ConsoleRpgEntities.Models.Characters;
using System.Collections.Generic;

namespace ConsoleRpgEntities.Models.Characters.Abilities
{
    public abstract class Ability : IAbility
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Many-to-many relationship with Character
        public virtual ICollection<Character> Characters { get; set; }

        protected Ability()
        {
            Characters = new List<Character>();
        }

        public abstract void Activate(ICharacter user, ICharacter target);
    }
}
