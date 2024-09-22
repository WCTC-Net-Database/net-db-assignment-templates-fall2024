using W7_assignment_template.Interfaces;

namespace W7_assignment_template.Services;

public class MapManager
{
    private IRoom _currentRoom;

    // Define the grid size for the map (adjust as needed)
    private const int gridRows = 5;
    private const int gridCols = 5;
    private string[,] mapGrid;

    public MapManager()
    {
        _currentRoom = null;
        mapGrid = new string[gridRows, gridCols];
    }

    public void UpdateCurrentRoom(IRoom currentRoom)
    {
        _currentRoom = currentRoom;
    }
    
    public void DisplayMap()
    {
        Console.Clear();
        Console.WriteLine("Map:");

        // Initialize the grid with empty spaces
        for (int i = 0; i < gridRows; i++)
        {
            for (int j = 0; j < gridCols; j++)
            {
                mapGrid[i, j] = "       ";  // Empty space with 7 chars
            }
        }

        // Start placing rooms from the current room
        if (_currentRoom != null)
        {
            // Use the center of the grid as the starting position
            int startRow = gridRows / 2;
            int startCol = gridCols / 2;

            // Recursively place rooms on the grid
            PlaceRoom(_currentRoom, startRow, startCol);
        }

        // Display the grid using string interpolation to format the output
        for (int i = 0; i < gridRows; i++)
        {
            // Display room names, aligned and padded
            for (int j = 0; j < gridCols; j++)
            {
                // Color the current room in green, others in white
                if (mapGrid[i, j] == "[  X  ]")  // Current room
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                // Print the room or empty space, ensuring it's always 7 characters wide
                Console.Write($"{mapGrid[i, j],-7}");  // Left-align to 7 chars
            }
            Console.WriteLine();
        }

        Console.ResetColor();
        Console.WriteLine();
    }

    // Recursive method to place rooms on the grid based on connections
    private void PlaceRoom(IRoom room, int row, int col)
    {
        // Check if the room is already placed on the grid
        if (mapGrid[row, col] != "       ")
            return;

        // Mark the room on the grid
        if (room == _currentRoom)
        {
            mapGrid[row, col] = "[  X  ]";  // Current room with 7 chars
        }
        else
        {
            string roomName = room.Name.Length > 5
                ? room.Name.Substring(0, 5)  // Truncate to 5 chars if necessary
                : room.Name.PadRight(5);     // Pad to 5 chars if shorter
            mapGrid[row, col] = $"[{roomName}]";  // Regular room
        }

        // Recursively place connected rooms
        if (room.North != null && row > 1)
        {
            mapGrid[row - 1, col] = "   |   ";  // Connector
            PlaceRoom(room.North, row - 2, col);  // Move up (North)
        }
        if (room.South != null && row < gridRows - 2)
        {
            mapGrid[row + 1, col] = "   |   ";  // Connector
            PlaceRoom(room.South, row + 2, col);  // Move down (South)
        }
        if (room.East != null && col < gridCols - 2)
        {
            mapGrid[row, col + 1] = "  ---  ";  // Connector
            PlaceRoom(room.East, row, col + 2);   // Move right (East)
        }
        if (room.West != null && col > 1)
        {
            mapGrid[row, col - 1] = "  ---  ";  // Connector
            PlaceRoom(room.West, row, col - 2);   // Move left (West)
        }
    }
}
