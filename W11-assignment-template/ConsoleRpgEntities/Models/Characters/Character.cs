using ConsoleRpgEntities.Models.Characters.Abilities;
using System.Collections.Generic;

namespace ConsoleRpgEntities.Models.Characters
{
    public abstract class Character : ICharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Many-to-many relationship with Ability
        public virtual ICollection<Ability> Abilities { get; set; }

        protected Character()
        {
            Abilities = new List<Ability>();
        }

        public abstract void Attack(ICharacter target);

        public void UseAbility(Ability ability, ICharacter target)
        {
            ability.Activate(this, target);
        }
    }
}
