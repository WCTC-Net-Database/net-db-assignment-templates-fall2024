﻿// <auto-generated />
using ConsoleRpgEntities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleRpgEntities.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20241013142219_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CharacterAbilities", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "AbilityId");

                    b.HasIndex("AbilityId");

                    b.ToTable("CharacterAbilities", (string)null);
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Abilities.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abilities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Ability");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Character");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Abilities.FireballAbility", b =>
                {
                    b.HasBaseType("ConsoleRpgEntities.Models.Characters.Abilities.Ability");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Radius")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("FireballAbility");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Abilities.TauntAbility", b =>
                {
                    b.HasBaseType("ConsoleRpgEntities.Models.Characters.Abilities.Ability");

                    b.Property<int>("TauntDuration")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("TauntAbility");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.MonsterTypes.Goblin", b =>
                {
                    b.HasBaseType("ConsoleRpgEntities.Models.Characters.Character");

                    b.Property<int>("AggressionLevel")
                        .HasColumnType("int");

                    b.Property<int>("Sneakiness")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Goblin");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Player", b =>
                {
                    b.HasBaseType("ConsoleRpgEntities.Models.Characters.Character");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Player");
                });

            modelBuilder.Entity("CharacterAbilities", b =>
                {
                    b.HasOne("ConsoleRpgEntities.Models.Characters.Abilities.Ability", null)
                        .WithMany()
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleRpgEntities.Models.Characters.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
