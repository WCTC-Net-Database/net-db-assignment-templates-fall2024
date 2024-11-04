using ConsoleRpgEntities.Models.Rooms.RoomFeatures;

namespace ConsoleRpgEntities.Models.Rooms.RoomTypes;

public class DefaultRoom : Room
{
    public DefaultRoom(int id, string name, string description) : base(id, name, description, "DefaultRoom")
    {
        // No features added
    }

    public override void UseFeature(RoomFeature feature)
    {
        Console.WriteLine("This room has no features to use.");
    }
}
