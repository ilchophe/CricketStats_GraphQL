IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Countries] (
    [Id] int NOT NULL IDENTITY,
    [CountryCode] nvarchar(5) NOT NULL,
    [CountryDesc] nvarchar(255) NOT NULL,
    [LastUpdated] datetimeoffset NOT NULL DEFAULT (SYSDATETIMEOFFSET()),
    CONSTRAINT [PK_Countries] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Dismissals] (
    [Id] int NOT NULL IDENTITY,
    [DismissalCode] nvarchar(5) NOT NULL,
    [DismissalDesc] nvarchar(255) NOT NULL,
    [LastUpdated] datetimeoffset NOT NULL DEFAULT (SYSDATETIMEOFFSET()),
    CONSTRAINT [PK_Dismissals] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [MatchTypes] (
    [Id] int NOT NULL IDENTITY,
    [MatchTypeName] nvarchar(50) NULL,
    [LastUpdated] datetimeoffset NOT NULL DEFAULT (SYSDATETIMEOFFSET()),
    CONSTRAINT [PK_MatchTypes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Players] (
    [Id] int NOT NULL IDENTITY,
    [PlayerName] nvarchar(255) NOT NULL,
    [PlayerSurname] nvarchar(255) NOT NULL,
    [CountryId] int NOT NULL,
    [Dob] datetime2 NOT NULL,
    [Retired] bit NOT NULL,
    [LastUpdated] datetimeoffset NOT NULL DEFAULT (SYSDATETIMEOFFSET()),
    CONSTRAINT [PK_Players] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Players_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Venues] (
    [Id] int NOT NULL IDENTITY,
    [VenueName] nvarchar(255) NULL,
    [VenueCity] nvarchar(150) NULL,
    [CountryId] int NOT NULL,
    [LastUpdated] datetimeoffset NOT NULL DEFAULT (SYSDATETIMEOFFSET()),
    CONSTRAINT [PK_Venues] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Venues_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Matches] (
    [Id] int NOT NULL IDENTITY,
    [MatchNumber] smallint NOT NULL,
    [HomeCountryId] int NOT NULL,
    [AwayCountryId] int NOT NULL,
    [VenueId] int NOT NULL,
    [MatchTypeId] int NOT NULL,
    [MatchStartDate] datetimeoffset NOT NULL,
    [TossWinnerCountryId] int NOT NULL,
    [LastUpdated] datetimeoffset NOT NULL DEFAULT (SYSDATETIMEOFFSET()),
    [CountryHomeId] int NULL,
    [CountryAwayId] int NULL,
    [CountryTossWonId] int NULL,
    CONSTRAINT [PK_Matches] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Matches_Countries_CountryAwayId] FOREIGN KEY ([CountryAwayId]) REFERENCES [Countries] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Matches_Countries_CountryHomeId] FOREIGN KEY ([CountryHomeId]) REFERENCES [Countries] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Matches_Countries_CountryTossWonId] FOREIGN KEY ([CountryTossWonId]) REFERENCES [Countries] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Matches_MatchTypes_MatchTypeId] FOREIGN KEY ([MatchTypeId]) REFERENCES [MatchTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Matches_Venues_VenueId] FOREIGN KEY ([VenueId]) REFERENCES [Venues] ([Id])
);
GO

CREATE TABLE [BattingInns] (
    [Id] int NOT NULL IDENTITY,
    [MatchId] int NOT NULL,
    [FirstInns] bit NOT NULL,
    [CountryId] int NOT NULL,
    [PlayerId] int NOT NULL,
    [Runs] int NOT NULL,
    [BallsFaced] int NOT NULL,
    [Fours] int NOT NULL,
    [Sixes] int NOT NULL,
    [BowlerPlayerId] int NULL,
    [FielderPlayerId] int NULL,
    [DismissalId] int NOT NULL,
    [LastUpdated] datetimeoffset NOT NULL DEFAULT (SYSDATETIMEOFFSET()),
    CONSTRAINT [PK_BattingInns] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BattingInns_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BattingInns_Dismissals_DismissalId] FOREIGN KEY ([DismissalId]) REFERENCES [Dismissals] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BattingInns_Matches_MatchId] FOREIGN KEY ([MatchId]) REFERENCES [Matches] ([Id]),
    CONSTRAINT [FK_BattingInns_Players_BowlerPlayerId] FOREIGN KEY ([BowlerPlayerId]) REFERENCES [Players] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_BattingInns_Players_FielderPlayerId] FOREIGN KEY ([FielderPlayerId]) REFERENCES [Players] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_BattingInns_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([Id])
);
GO

CREATE TABLE [BowlingInns] (
    [Id] int NOT NULL IDENTITY,
    [MatchId] int NOT NULL,
    [FirstInns] bit NOT NULL,
    [CountryId] int NOT NULL,
    [PlayerId] int NOT NULL,
    [Runs] int NOT NULL,
    [Wickets] int NOT NULL,
    [Maidens] int NOT NULL,
    [Overs] int NOT NULL,
    [Extras] int NOT NULL,
    [LastUpdated] datetimeoffset NOT NULL DEFAULT (SYSDATETIMEOFFSET()),
    CONSTRAINT [PK_BowlingInns] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BowlingInns_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BowlingInns_Matches_MatchId] FOREIGN KEY ([MatchId]) REFERENCES [Matches] ([Id]),
    CONSTRAINT [FK_BowlingInns_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([Id])
);
GO

CREATE INDEX [IX_BattingInns_BowlerPlayerId] ON [BattingInns] ([BowlerPlayerId]);
GO

CREATE INDEX [IX_BattingInns_CountryId] ON [BattingInns] ([CountryId]);
GO

CREATE INDEX [IX_BattingInns_DismissalId] ON [BattingInns] ([DismissalId]);
GO

CREATE INDEX [IX_BattingInns_FielderPlayerId] ON [BattingInns] ([FielderPlayerId]);
GO

CREATE INDEX [IX_BattingInns_MatchId] ON [BattingInns] ([MatchId]);
GO

CREATE INDEX [IX_BattingInns_PlayerId] ON [BattingInns] ([PlayerId]);
GO

CREATE INDEX [IX_BowlingInns_CountryId] ON [BowlingInns] ([CountryId]);
GO

CREATE INDEX [IX_BowlingInns_MatchId] ON [BowlingInns] ([MatchId]);
GO

CREATE INDEX [IX_BowlingInns_PlayerId] ON [BowlingInns] ([PlayerId]);
GO

CREATE INDEX [IX_Matches_CountryAwayId] ON [Matches] ([CountryAwayId]);
GO

CREATE INDEX [IX_Matches_CountryHomeId] ON [Matches] ([CountryHomeId]);
GO

CREATE INDEX [IX_Matches_CountryTossWonId] ON [Matches] ([CountryTossWonId]);
GO

CREATE INDEX [IX_Matches_MatchTypeId] ON [Matches] ([MatchTypeId]);
GO

CREATE INDEX [IX_Matches_VenueId] ON [Matches] ([VenueId]);
GO

CREATE INDEX [IX_Players_CountryId] ON [Players] ([CountryId]);
GO

CREATE INDEX [IX_Venues_CountryId] ON [Venues] ([CountryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210520181232_AddCricketStatsToDB', N'5.0.6');
GO

COMMIT;
GO