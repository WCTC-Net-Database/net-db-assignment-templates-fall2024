namespace ConsoleRpgEntities.Models.Rooms.RoomFeatures
{
    public class TrapFeature : RoomFeature
    {
        public override void ExecuteFeature(IRoom room)
        {
            Console.WriteLine("A trap has been triggered! The player takes damage.");
            room.UseFeature(this);
        }

    }
}
