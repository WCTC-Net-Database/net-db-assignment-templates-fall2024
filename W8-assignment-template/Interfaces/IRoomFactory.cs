using W8_assignment_template.Services;

namespace W8_assignment_template.Interfaces;

public interface IRoomFactory
{
    IRoom CreateRoom(string roomType, OutputManager outputManager);
}
