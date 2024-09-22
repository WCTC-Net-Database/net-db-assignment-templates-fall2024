using Microsoft.Extensions.DependencyInjection;
using W8_assignment_template.Interfaces;
using W8_assignment_template.Models.Characters;
using W8_assignment_template.Models.Rooms;
using W8_assignment_template.Services;

namespace W8_assignment_template;

internal class Program
{
    private static void ConfigureServices(IServiceCollection services)
    {
        // Register for DI
        services.AddTransient<GameEngine>();
        services.AddTransient<MenuManager>();
        services.AddTransient<MapManager>();
        services.AddTransient<OutputManager>();

        // Register Room and RoomFactory
        services.AddTransient<IRoom, Room>();
        services.AddTransient<IRoomFactory, RoomFactory>();

        // Register CharacterFactory
        services.AddTransient<ICharacterFactory, CharacterFactory>();

        // Register GameEngine with dependency injection for characters and RoomFactory
        services.AddTransient<GameEngine>(provider =>
        {
            var characterFactory = provider.GetService<ICharacterFactory>();
            var roomFactory = provider.GetService<IRoomFactory>();
            var menuManager = provider.GetService<MenuManager>();
            var mapManager = provider.GetService<MapManager>();
            var outputManager = provider.GetService<OutputManager>();

            return new GameEngine(characterFactory, roomFactory, menuManager, mapManager, outputManager);
        });
    }

    private static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var gameEngine = serviceProvider.GetService<GameEngine>();

        gameEngine?.Run();
    }
}
