using Microsoft.Extensions.DependencyInjection;
using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;
using W6_assignment_template.Services;

namespace W6_assignment_template
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var gameEngine = serviceProvider.GetService<GameEngine>();

            gameEngine?.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddKeyedTransient<IEntity, Character>("character");
            services.AddKeyedTransient<IEntity, Goblin>("goblin");
            services.AddKeyedTransient<IEntity, Ghost>("ghost");

            services.AddTransient<GameEngine>(provider =>
            {
                var character = provider.GetKeyedService<IEntity>("character");
                var goblin = provider.GetKeyedService<IEntity>("goblin");
                var ghost = provider.GetKeyedService<IEntity>("ghost");

                return new GameEngine(character, goblin, ghost);
            });
        }
    }
}
