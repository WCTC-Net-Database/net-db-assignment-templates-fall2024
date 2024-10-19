using ConsoleRpg.Helpers;

namespace ConsoleRpg.Interfaces;

public interface IRoomFactory
{
    IRoom CreateRoom(string roomType, OutputManager outputManager);
}
