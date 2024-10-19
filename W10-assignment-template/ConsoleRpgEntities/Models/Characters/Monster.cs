namespace ConsoleRpgEntities.Models.Characters
{
    public abstract class Monster : Character
    {
        // Common properties for all monsters
        public int AggressionLevel { get; set; }

        protected Monster()
        {
        }

        // Monster-specific attack logic to be overridden
        public abstract override void Attack(ICharacter target);
    }

}
