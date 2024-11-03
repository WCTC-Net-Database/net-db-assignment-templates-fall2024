using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Npcs;
using ConsoleRpgEntities.Models.Rooms.RoomFeatures;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleRpgEntities.Models.Rooms
{
    public abstract class Room : IRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RoomType { get; set; }  // Discriminator for TPH

        public List<RoomFeature> Features { get; set; } 

        public virtual IEnumerable<Player> Players { get; set; } 

        public virtual IEnumerable<Character> Characters { get; set; } 

        public virtual IEnumerable<Npc> Npcs { get; set; } = new List<Npc>();

        // Navigation for connecting rooms
        [ForeignKey("NorthRoomId")]
        public virtual Room? North { get; set; }
        public int? NorthRoomId { get; set; }

        [ForeignKey("SouthRoomId")]
        public virtual Room? South { get; set; }
        public int? SouthRoomId { get; set; }

        [ForeignKey("EastRoomId")]
        public virtual Room? East { get; set; }
        public int? EastRoomId { get; set; }

        [ForeignKey("WestRoomId")]
        public virtual Room? West { get; set; }
        public int? WestRoomId { get; set; }

        public Room(int id, string name, string description, string roomType)
        {
            Id = id;
            Name = name;
            Description = description;
            RoomType = roomType;
            Features = new List<RoomFeature>();
        }

        public void AddFeature(RoomFeature feature)
        {
            Features.Add(feature);
        }

        public virtual void UseFeature(RoomFeature feature)
        {
            feature.ExecuteFeature(this);
        }
    }
}
