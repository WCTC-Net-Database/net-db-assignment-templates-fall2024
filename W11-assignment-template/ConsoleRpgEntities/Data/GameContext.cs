using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Characters.Abilities;
using ConsoleRpgEntities.Models.Characters.MonsterTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsoleRpgEntities.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure TPH for Character hierarchy
            modelBuilder.Entity<Character>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Player>("Player")
                .HasValue<Goblin>("Goblin");

            // Configure TPH for Ability hierarchy
            modelBuilder.Entity<Ability>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<TauntAbility>("TauntAbility")
                .HasValue<FireballAbility>("FireballAbility");

            // Configure many-to-many relationship
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Abilities)
                .WithMany(a => a.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterAbilities",
                    j => j.HasOne<Ability>().WithMany().HasForeignKey("AbilityId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Character>().WithMany().HasForeignKey("CharacterId").OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.ToTable("CharacterAbilities");
                        j.HasKey("CharacterId", "AbilityId");
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

        public void Seed()
        {
            // Create abilities
            var tauntAbility = new TauntAbility
            {
                Name = "Taunt",
                TauntDuration = 5
            };

            var fireballAbility = new FireballAbility
            {
                Name = "Fireball",
                Damage = 30,
                Radius = 3
            };

            // Create player
            var player = new Player
            {
                Name = "Hero"
            };
            player.Abilities.Add(fireballAbility);

            // Create goblin
            var goblin = new Goblin
            {
                Name = "Goblin Grunt",
                AggressionLevel = 2,
                Sneakiness = 8
            };
            goblin.Abilities.Add(tauntAbility);

            // Add entities to context
            Characters.Add(player);
            Characters.Add(goblin);
            Abilities.Add(tauntAbility);
            Abilities.Add(fireballAbility);

            SaveChanges();
        }
    }
}


