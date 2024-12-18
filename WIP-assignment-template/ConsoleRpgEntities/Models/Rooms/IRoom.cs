﻿using ConsoleRpgEntities.Models.Rooms.RoomFeatures;

namespace ConsoleRpgEntities.Models.Rooms
{
    public interface IRoom
    {
        string Name { get; set; }
        string Description { get; set; }
        string RoomType { get; set; }

        void AddFeature(RoomFeature feature);
        void UseFeature(RoomFeature feature);
    }

}
