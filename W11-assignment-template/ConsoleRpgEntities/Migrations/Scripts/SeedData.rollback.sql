    -- Delete from CharacterAbilities
    DELETE FROM CharacterAbilities
WHERE (CharacterId = 1 AND AbilityId = 2) OR (CharacterId = 2 AND AbilityId = 1);

-- Delete Characters
    DELETE FROM Characters
WHERE Id IN (1, 2);

-- Delete Abilities
    DELETE FROM Abilities
WHERE Id IN (1, 2);
