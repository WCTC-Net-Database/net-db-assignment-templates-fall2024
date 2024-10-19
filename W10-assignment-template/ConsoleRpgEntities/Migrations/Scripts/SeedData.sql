-- Enable IDENTITY_INSERT for Abilities
    SET IDENTITY_INSERT Abilities ON;

-- Insert Abilities
    INSERT INTO Abilities (Id, Name, Discriminator, TauntDuration, Damage, Radius)
VALUES
    (1, 'Taunt', 'TauntAbility', 5, NULL, NULL),
(2, 'Fireball', 'FireballAbility', NULL, 30, 3);

-- Disable IDENTITY_INSERT for Abilities
    SET IDENTITY_INSERT Abilities OFF;

-- Enable IDENTITY_INSERT for Characters
    SET IDENTITY_INSERT Characters ON;

-- Insert Characters
    INSERT INTO Characters (Id, Name, Discriminator, AggressionLevel, Sneakiness, Experience)
VALUES
    (1, 'Hero', 'Player', NULL, NULL, 0),
(2, 'Goblin Grunt', 'Goblin', 2, 8, NULL);

-- Disable IDENTITY_INSERT for Characters
    SET IDENTITY_INSERT Characters OFF;

-- Insert into CharacterAbilities
INSERT INTO CharacterAbilities (CharacterId, AbilityId)
VALUES
    (1, 2), -- Hero has Fireball
(2, 1); -- Goblin Grunt has Taunt
