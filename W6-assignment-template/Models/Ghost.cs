using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Ghost : IEntity, IFlyable
    {
        public string Name { get; set; }

        public void Attack(IEntity target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} with a chilling touch.");
        }

        public void Move()
        {
            Console.WriteLine($"{Name} floats silently.");
        }

        public Action? FlyAction { get; set; }
        public void Fly()
        {
            Console.WriteLine($"{Name} flies rapidly through the air.");
        }
    }
}
