using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Rooms.RoomFeatures;

namespace ConsoleRpgEntities.Models.Rooms
{
    public abstract class Room : IRoom
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string RoomType { get; set; }  // Discriminator for TPH

        public List<IRoomFeature> Features { get; set; } = new List<IRoomFeature>();

        public virtual ICollection<Player> Players { get; set; } = new List<Player>();

        public virtual ICollection<Monster> Monsters { get; set; } = new List<Monster>();

        public virtual ICollection<Npc> Npcs { get; set; } = new List<Npc>();

        // Navigation for connecting rooms
        public virtual Room? North { get; set; }
        public virtual Room? South { get; set; }
        public virtual Room? East { get; set; }
        public virtual Room? West { get; set; }

        public Room(int id, string name, string description, string roomType)
        {
            Id = id;
            Name = name;
            Description = description;
            RoomType = roomType;
        }

        public void AddFeature(IRoomFeature feature)
        {
            Features.Add(feature);
        }

        public virtual void UseFeature(IRoomFeature feature)
        {
            feature.ExecuteFeature(this);
        }
    }
}
