using ConsoleRpgEntities.Models.Rooms.RoomFeatures;

namespace ConsoleRpgEntities.Models.Rooms.RoomTypes;

public class TrapRoom : Room
{
    public TrapRoom(int id, string name, string description) : base(id, name, description, "TrapRoom")
    {
        AddFeature(new TrapFeature());
    }
}