using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable, IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }

        // Foreign key
        public int? EquipmentId { get; set; }

        // Navigation properties
        public virtual Equipment Equipment { get; set; }
        public virtual ICollection<Ability> Abilities { get; set; }

        public void Attack(ITargetable target)
        {
            // Player-specific attack logic
            Console.WriteLine($"{Name} attacks {target.Name} with a {Equipment.Weapon.Name} dealing {Equipment.Weapon.Attack} damage!");
            target.Health -= Equipment.Weapon.Attack;
            System.Console.WriteLine($"{target.Name} has {target.Health} health remaining.");

        }

        public void UseAbility(IAbility ability, ITargetable target)
        {
            if (Abilities.Contains(ability))
            {
                ability.Activate(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} does not have the ability {ability.Name}!");
            }
        }
    }

    public class Equipment
    {
        public int Id { get; set; }

        // SQL Server enforces cascading delete rules strictly
        // so Entity Framework will assume DeleteBehavior.Cascade for relationships
        public int? WeaponId { get; set; }  // Nullable to avoid cascade issues
        public int? ArmorId { get; set; }   // Nullable to avoid cascade issues

        // Navigation properties
        [ForeignKey("WeaponId")]
        public virtual Item Weapon { get; set; }

        [ForeignKey("ArmorId")]
        public virtual Item Armor { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
    }
}
