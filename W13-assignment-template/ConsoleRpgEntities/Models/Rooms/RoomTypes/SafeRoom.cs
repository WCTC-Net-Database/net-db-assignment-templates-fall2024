using ConsoleRpgEntities.Models.Rooms.RoomFeatures;

namespace ConsoleRpgEntities.Models.Rooms.RoomTypes;

public class SafeRoom : Room
{
    public SafeRoom(int id, string name, string description) : base(id, name, description, "SafeRoom")
    {
        // No features added
    }

    public override void UseFeature(RoomFeature feature)
    {
        Console.WriteLine("This is a safe room. No features to use.");
    }
}
