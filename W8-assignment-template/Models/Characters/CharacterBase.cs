using W8_assignment_template.Interfaces;
using W8_assignment_template.Services;

namespace W8_assignment_template.Models.Characters
{
    public abstract class CharacterBase : ICharacter
    {
        public IRoom CurrentRoom;
        public string Name { get; set; }
        private readonly OutputManager _outputManager;

        protected CharacterBase(string name, IRoom startingRoom, OutputManager outputManager)
        {
            Name = name;
            CurrentRoom = startingRoom;
            _outputManager = outputManager;
            CurrentRoom.Enter();
        }

        public void Attack(ICharacter target)
        {
            _outputManager.WriteLine($"{Name} attacks {target.Name} with a chilling touch.", ConsoleColor.Blue);
        }

        public void EnterRoom(IRoom room)
        {
            CurrentRoom = room;
            _outputManager.WriteLine($"{Name} has entered {CurrentRoom.Name}. {CurrentRoom.Description}", ConsoleColor.Green);
        }

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
                _outputManager.WriteLine($"{Name} cannot move that way.", ConsoleColor.Yellow);
            }
        }

        public abstract void UniqueBehavior();
    }
}
