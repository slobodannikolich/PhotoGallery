BEGIN TRANSACTION;
GO

CREATE TABLE [Authors] (
    [AuthorID] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [BirthdayDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY NONCLUSTERED ([AuthorID])
);
GO

CREATE TABLE [Categories] (
    [CategoryID] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID])
);
GO

CREATE TABLE [Clients] (
    [ClientID] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(35) NOT NULL,
    [LastName] nvarchar(35) NOT NULL,
    [Gender] int NOT NULL,
    [Phone] nvarchar(15) NOT NULL,
    [BirthdayDate] datetime2 NOT NULL,
    [ExternalUserID] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([ClientID]),
    CONSTRAINT [FK_Clients_AspNetUsers_ExternalUserID] FOREIGN KEY ([ExternalUserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ClientCollections] (
    [ClientCollectionID] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [VisibleStatus] int NOT NULL,
    [ClientID] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ClientCollections] PRIMARY KEY ([ClientCollectionID]),
    CONSTRAINT [FK_ClientCollections_Clients_ClientID] FOREIGN KEY ([ClientID]) REFERENCES [Clients] ([ClientID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Paintings] (
    [PaintingID] uniqueidentifier NOT NULL,
    [PaintingName] nvarchar(50) NOT NULL,
    [CreationYear] int NOT NULL,
    [PaintingTehnique] int NOT NULL,
    [Documentation] nvarchar(200) NOT NULL,
    [Desctiprion] nvarchar(200) NOT NULL,
    [VisibleStatus] int NOT NULL,
    [AuthorID] uniqueidentifier NOT NULL,
    [ClientCollectionID] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Paintings] PRIMARY KEY ([PaintingID]),
    CONSTRAINT [FK_Paintings_Authors_AuthorID] FOREIGN KEY ([AuthorID]) REFERENCES [Authors] ([AuthorID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Paintings_ClientCollections_ClientCollectionID] FOREIGN KEY ([ClientCollectionID]) REFERENCES [ClientCollections] ([ClientCollectionID]) ON DELETE CASCADE
);
GO

CREATE TABLE [ClientFavorites] (
    [ClientFavoriteID] uniqueidentifier NOT NULL,
    [ClientID] uniqueidentifier NOT NULL,
    [PaintingID] uniqueidentifier NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    CONSTRAINT [PK_ClientFavorites] PRIMARY KEY ([ClientFavoriteID]),
    CONSTRAINT [FK_ClientFavorites_Clients_ClientID] FOREIGN KEY ([ClientID]) REFERENCES [Clients] ([ClientID]) ON DELETE CASCADE,
    CONSTRAINT [FK_ClientFavorites_Paintings_PaintingID] FOREIGN KEY ([PaintingID]) REFERENCES [Paintings] ([PaintingID])
);
GO

CREATE TABLE [PaintingCategorys] (
    [PaintingCategoryID] uniqueidentifier NOT NULL,
    [PaintingID] uniqueidentifier NOT NULL,
    [CategoryID] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PaintingCategorys] PRIMARY KEY ([PaintingCategoryID]),
    CONSTRAINT [FK_PaintingCategorys_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Categories] ([CategoryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_PaintingCategorys_Paintings_PaintingID] FOREIGN KEY ([PaintingID]) REFERENCES [Paintings] ([PaintingID]) ON DELETE CASCADE
);
GO

CREATE UNIQUE CLUSTERED INDEX [IX_Authors_FirstName_LastName] ON [Authors] ([FirstName], [LastName]);
GO

CREATE INDEX [IX_ClientCollections_ClientID] ON [ClientCollections] ([ClientID]);
GO

CREATE INDEX [IX_ClientFavorites_ClientID] ON [ClientFavorites] ([ClientID]);
GO

CREATE INDEX [IX_ClientFavorites_PaintingID] ON [ClientFavorites] ([PaintingID]);
GO

CREATE INDEX [IX_Clients_ExternalUserID] ON [Clients] ([ExternalUserID]);
GO

CREATE INDEX [IX_PaintingCategorys_CategoryID] ON [PaintingCategorys] ([CategoryID]);
GO

CREATE INDEX [IX_PaintingCategorys_PaintingID] ON [PaintingCategorys] ([PaintingID]);
GO

CREATE INDEX [IX_Paintings_AuthorID] ON [Paintings] ([AuthorID]);
GO

CREATE INDEX [IX_Paintings_ClientCollectionID] ON [Paintings] ([ClientCollectionID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221019104158_AddedBusinessLogicEntities', N'6.0.8');
GO

COMMIT;
GO

