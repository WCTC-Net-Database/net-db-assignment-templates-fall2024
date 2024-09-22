using W7_assignment_template.Interfaces;

namespace W7_assignment_template.Models.Characters
{
    public abstract class CharacterBase : ICharacter
    {
        protected IRoom CurrentRoom;
        public string Name { get; set; }

        protected CharacterBase(string name, IRoom startingRoom)
        {
            Name = name;
            CurrentRoom = startingRoom;
            CurrentRoom.Enter();
        }

        public void Attack(ICharacter target)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} attacks {target.Name} with a chilling touch.");
            Console.ResetColor();
        }

        // Common room entry logic
        public void EnterRoom(IRoom room)
        {
            CurrentRoom = room;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} has entered {CurrentRoom.Name}. {CurrentRoom.Description}");
            Console.ResetColor();
        }

        // Common movement logic
        public void Move(string? direction)
        {
            IRoom? nextRoom;
            switch (direction?.ToLower())
            {
                case "north":
                    nextRoom = CurrentRoom.North;
                    break;
                case "south":
                    nextRoom = CurrentRoom.South;
                    break;
                case "east":
                    nextRoom = CurrentRoom.East;
                    break;
                case "west":
                    nextRoom = CurrentRoom.West;
                    break;
                default:
                    nextRoom = null;
                    break;
            }

            if (nextRoom != null)
            {
                EnterRoom(nextRoom);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Name} cannot move that way.");
                Console.ResetColor();
            }
        }

        // Abstract method for unique behavior to be implemented by derived classes
        public abstract void UniqueBehavior();
    }
}
