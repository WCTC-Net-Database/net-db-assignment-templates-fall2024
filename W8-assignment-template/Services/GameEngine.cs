using W8_assignment_template.Interfaces;
using W8_assignment_template.Models.Characters;
using W8_assignment_template.Services;

namespace W8_assignment_template.Services
{
    public class GameEngine
    {
        private readonly ICharacterFactory _characterFactory;
        private readonly IRoomFactory _roomFactory;
        private readonly MenuManager _menuManager;
        private readonly MapManager _mapManager;
        private readonly OutputManager _outputManager;
        private ICharacter _player;

        public GameEngine(ICharacterFactory characterFactory, IRoomFactory roomFactory, MenuManager menuManager, MapManager mapManager, OutputManager outputManager)
        {
            _characterFactory = characterFactory;
            _roomFactory = roomFactory;
            _menuManager = menuManager;
            _mapManager = mapManager;
            _outputManager = outputManager;
        }

        public void Run()
        {
            if (_menuManager.ShowMainMenu())
            {
                SetupGame();
            }
        }

        private void SetupGame()
        {
            var startingRoom = SetupRooms();
            _player = _characterFactory.CreateCharacter("player", "Hero", startingRoom, _outputManager);
            _outputManager.WriteLine($"{_player.Name} has entered the game.", ConsoleColor.Green);
            _mapManager.UpdateCurrentRoom(startingRoom);

            Thread.Sleep(1000);
            GameLoop();
        }

        private IRoom SetupRooms()
        {
            var entrance = _roomFactory.CreateRoom("entrance", _outputManager);
            var treasureRoom = _roomFactory.CreateRoom("treasure", _outputManager);
            var dungeonRoom = _roomFactory.CreateRoom("dungeon", _outputManager);
            var library = _roomFactory.CreateRoom("library", _outputManager);
            var armory = _roomFactory.CreateRoom("armory", _outputManager);
            var garden = _roomFactory.CreateRoom("garden", _outputManager);

            entrance.North = treasureRoom;
            entrance.West = library;
            entrance.East = garden;

            treasureRoom.South = entrance;
            treasureRoom.West = dungeonRoom;

            dungeonRoom.East = treasureRoom;

            library.East = entrance;
            library.South = armory;

            armory.North = library;

            garden.West = entrance;

            return entrance;
        }

        private void GameLoop()
        {
            // reset the output manager
            _outputManager.Clear();

            while (true)
            {
                _mapManager.DisplayMap();
                _outputManager.WriteLine("Choose an action:", ConsoleColor.Cyan);
                _outputManager.WriteLine("1. Move North");
                _outputManager.WriteLine("2. Move South");
                _outputManager.WriteLine("3. Move East");
                _outputManager.WriteLine("4. Move West");
                _outputManager.WriteLine("5. Exit Game");
                _outputManager.Display();

                string input = Console.ReadLine();
                string? direction = null;

                switch (input)
                {
                    case "1":
                        direction = "north";
                        break;
                    case "2":
                        direction = "south";
                        break;
                    case "3":
                        direction = "east";
                        break;
                    case "4":
                        direction = "west";
                        break;
                    case "5":
                        _outputManager.WriteLine("Exiting game...", ConsoleColor.Red);
                        _outputManager.Display();
                        Environment.Exit(0);
                        break;
                    default:
                        _outputManager.WriteLine("Invalid selection. Please choose a valid option.", ConsoleColor.Red);
                        break;
                }

                if (!string.IsNullOrEmpty(direction))
                {
                    _outputManager.Clear();
                    _player.Move(direction);
                    _mapManager.UpdateCurrentRoom(((CharacterBase)_player).CurrentRoom);
                }
            }
        }
    }
}
