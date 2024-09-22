using W8_assignment_template.Interfaces;
using W8_assignment_template.Services;

public interface IRoomFactory
{
    IRoom CreateRoom(string roomType, OutputManager outputManager);
}
