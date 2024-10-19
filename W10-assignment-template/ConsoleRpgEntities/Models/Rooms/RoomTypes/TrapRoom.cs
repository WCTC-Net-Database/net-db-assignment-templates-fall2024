using ConsoleRpgEntities.Models.Rooms.RoomFeatures;

namespace ConsoleRpgEntities.Models.Rooms.RoomTypes;

public class TrapRoom : Room
{
    public TrapRoom(int id, string name, string description) : base(id, name, description, "Trap Room")
    {
        AddFeature(new TrapFeature());
    }


    public override void UseFeature(IRoomFeature feature)
    {
        Console.WriteLine("You've triggered a trap!");
        feature.ExecuteFeature(this);
    }
}