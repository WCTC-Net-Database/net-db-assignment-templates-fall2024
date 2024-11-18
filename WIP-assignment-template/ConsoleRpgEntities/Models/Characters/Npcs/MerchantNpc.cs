using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Characters.Npcs
{
    public class MerchantNpc : Npc
    {
        public override void Talk(ICharacter character)
        {
            Console.WriteLine($"Hello {character.Name}.  What would you like to buy?");
        }
    }
}
