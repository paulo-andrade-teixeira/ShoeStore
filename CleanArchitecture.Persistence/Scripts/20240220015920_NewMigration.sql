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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240220015920_NewMigration'
)
BEGIN
    CREATE TABLE [SegmentEntity] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [DateCreated] datetimeoffset NOT NULL,
        [DateUpdated] datetimeoffset NULL,
        [DateDeleted] datetimeoffset NULL,
        [IsDeleted] bit NOT NULL,
        CONSTRAINT [PK_SegmentEntity] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240220015920_NewMigration'
)
BEGIN
    CREATE TABLE [Products] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Code] nvarchar(max) NOT NULL,
        [Price] float NOT NULL,
        [SegmentId] uniqueidentifier NOT NULL,
        [DateCreated] datetimeoffset NOT NULL,
        [DateUpdated] datetimeoffset NULL,
        [DateDeleted] datetimeoffset NULL,
        [IsDeleted] bit NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_SegmentEntity_SegmentId] FOREIGN KEY ([SegmentId]) REFERENCES [SegmentEntity] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240220015920_NewMigration'
)
BEGIN
    CREATE INDEX [IX_Products_SegmentId] ON [Products] ([SegmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240220015920_NewMigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240220015920_NewMigration', N'8.0.2');
END;
GO

COMMIT;
GO

