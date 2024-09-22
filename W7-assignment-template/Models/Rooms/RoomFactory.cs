using W7_assignment_template.Interfaces;

namespace W7_assignment_template.Models.Rooms
{
    public class RoomFactory : IRoomFactory
    {
        public IRoom CreateRoom(string roomType)
        {
            switch (roomType.ToLower())
            {
                case "treasure":
                    return new Room("Treasure Room", "Filled with gold and treasures.");
                case "dungeon":
                    return new Room("Dungeon", "Dark and damp, with echoes of past prisoners.");
                case "entrance":
                    return new Room("Entrance Hall", "A large room with high ceilings.");
                case "library":
                    return new Room("Library", "Shelves filled with ancient books.");
                case "armory":
                    return new Room("Armory", "Weapons and armor line the walls.");
                case "garden":
                    return new Room("Garden", "A peaceful garden with blooming flowers.");
                default:
                    return new Room("Generic Room", "A simple room.");
            }
        }
    }
}
