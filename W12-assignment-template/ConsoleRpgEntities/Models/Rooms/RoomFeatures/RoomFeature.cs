namespace ConsoleRpgEntities.Models.Rooms.RoomFeatures;

public abstract class RoomFeature : IRoomFeature
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public void AddFeature(IRoom room)
    {
        room.AddFeature(this);
    }

    public abstract void ExecuteFeature(IRoom room);
}