namespace ConsoleRpgEntities.Models.Rooms.RoomFeatures;

public interface IRoomFeature
{
    int Id { get; set; }
    void ExecuteFeature(IRoom room);
}