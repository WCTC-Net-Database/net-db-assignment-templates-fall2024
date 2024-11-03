using ConsoleRpg.Interfaces;

namespace ConsoleRpg.Models.Characters;

public class Goblin : CharacterBase, ILootable
{
    public string Treasure { get; set; }

    public Goblin()
    {
    }

    public Goblin(string name, string type, int level, int hp, string treasure, IRoom startingRoom) : base(name, type, level, hp, startingRoom)
    {
        Treasure = treasure;
    }

    public override void UniqueBehavior()
    {
        throw new NotImplementedException();
    }
}
