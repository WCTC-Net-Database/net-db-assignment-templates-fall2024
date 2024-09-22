using W8_assignment_template.Interfaces;
using W8_assignment_template.Services;

namespace W8_assignment_template.Models.Rooms
{
    public class Room : IRoom
    {
        public string Name { get; }
        public IRoom? North { get; set; }
        public IRoom? South { get; set; }
        public IRoom? West { get; set; }
        public IRoom? East { get; set; }
        public string Description { get; }
        private readonly OutputManager _outputManager;

        public Room(string name, string description, OutputManager outputManager)
        {
            Name = name;
            Description = description;
            _outputManager = outputManager;
        }

        public void Enter()
        {
            _outputManager.WriteLine($"You have entered {Name}. {Description}", ConsoleColor.Green);
        }
    }
}
