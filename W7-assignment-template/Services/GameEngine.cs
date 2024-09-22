using W7_assignment_template.Interfaces;

namespace W7_assignment_template.Services
{
    public class GameEngine
    {
        private readonly ICharacterFactory _characterFactory;
        private readonly IRoomFactory _roomFactory;
        private readonly MenuManager _menuManager;
        private readonly MapManager _mapManager;
        private ICharacter _player; 
        private IRoom _currentRoom; // Tracks current room

        public GameEngine(ICharacterFactory characterFactory, IRoomFactory roomFactory, MenuManager menuManager, MapManager mapManager)
        {
            _characterFactory = characterFactory;
            _roomFactory = roomFactory;
            _menuManager = menuManager;
            _mapManager = mapManager;
        }

        public void Run()
        {
            // Show main menu and check if the user wants to start the game
            if (_menuManager.ShowMainMenu())
            {
                // Setup game world after menu interaction
                SetupGame();
            }
        }

        private void SetupGame()
        {
            // Setup rooms and assign starting room
            _currentRoom = SetupRooms();

            // Create player using CharacterFactory
            _player = _characterFactory.CreateCharacter("player", "Hero", _currentRoom);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{_player.Name} has entered the game.");
            Console.ResetColor();

            // Update map manager with the current room
            _mapManager.UpdateCurrentRoom(_currentRoom);

            // Start game loop
            GameLoop();
        }

        private IRoom SetupRooms()
        {
            // Create rooms using RoomFactory
            var entrance = _roomFactory.CreateRoom("entrance");
            var treasureRoom = _roomFactory.CreateRoom("treasure");
            var dungeonRoom = _roomFactory.CreateRoom("dungeon");
            var library = _roomFactory.CreateRoom("library");
            var armory = _roomFactory.CreateRoom("armory");
            var garden = _roomFactory.CreateRoom("garden");

            // Link rooms together
            entrance.North = treasureRoom;
            treasureRoom.South = entrance;
            treasureRoom.West = dungeonRoom;
            library.East = armory;
            armory.West = library;
            entrance.West = library;
            entrance.East = garden;
            garden.West = entrance;
            dungeonRoom.East = treasureRoom;

            return entrance; // Starting room
        }

        // Game loop that handles movement and interaction
        private void GameLoop()
        {
            while (true)
            {
                _mapManager.DisplayMap();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Move North");
                Console.WriteLine("2. Move South");
                Console.WriteLine("3. Move East");
                Console.WriteLine("4. Move West");
                Console.WriteLine("5. Exit Game");
                Console.ResetColor();

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        _player.Move("north");
                        break;
                    case "2":
                        _player.Move("south");
                        break;
                    case "3":
                        _player.Move("east");
                        break;
                    case "4":
                        _player.Move("west");
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Exiting game...");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid selection. Please choose a valid option.");
                        Console.ResetColor();
                        break;
                }

                // Update map manager with the current room after movement
                _mapManager.UpdateCurrentRoom(_currentRoom);
            }
        }
    }
}
