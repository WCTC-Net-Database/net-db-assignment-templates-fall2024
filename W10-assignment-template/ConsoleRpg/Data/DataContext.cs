﻿using System.Text.Json;
using ConsoleRpg.Helpers;
using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Data;

public class DataContext : IContext
{
    private readonly JsonSerializerOptions options;

    public DataContext(OutputManager outputManager)
    {
        options = new JsonSerializerOptions
        {
            Converters = { new CharacterBaseConverter(outputManager) },
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        LoadData();
    }

    public void AddCharacter(CharacterBase character)
    {
        Characters.Add(character);
        SaveData();
    }

    public List<CharacterBase> Characters { get; set; }

    public void DeleteCharacter(string characterName)
    {
        var character = Characters.FirstOrDefault(c => c.Name == characterName);
        if (character != null)
        {
            Characters.Remove(character);
            SaveData();
        }
    }

    public void UpdateCharacter(CharacterBase character)
    {
        var existingCharacter = Characters.FirstOrDefault(c => c.Name == character.Name);
        if (existingCharacter != null)
        {
            existingCharacter.Level = character.Level;
            existingCharacter.HP = character.HP;

            if (existingCharacter is Player player && character is Player updatedPlayer)
            {
                player.Gold = updatedPlayer.Gold; // Specific to Player
            }

            if (existingCharacter is Goblin goblin && character is Goblin updatedGoblin)
            {
                goblin.Treasure = updatedGoblin.Treasure; // Specific to Goblin
            }

            SaveData();
        }
    }

    private void LoadData()
    {
        var jsonData = File.ReadAllText("Files/input.json");
        Characters = JsonSerializer.Deserialize<List<CharacterBase>>(jsonData, options); // Load all character types
    }

    private void SaveData()
    {
        var jsonData = JsonSerializer.Serialize(Characters, options);
        File.WriteAllText("Files/input.json", jsonData);
    }
}
