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
CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [DateOfBirth] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);

CREATE TABLE [Outils] (
    [Id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    [description] nvarchar(max) NULL,
    CONSTRAINT [PK_Outils] PRIMARY KEY ([Id])
);

CREATE TABLE [Locations] (
    [ClientId] int NOT NULL,
    [OutilId] int NOT NULL,
    [Date] datetime2 NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY ([ClientId], [OutilId], [Date]),
    CONSTRAINT [FK_Locations_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Locations_Outils_OutilId] FOREIGN KEY ([OutilId]) REFERENCES [Outils] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Locations_OutilId] ON [Locations] ([OutilId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241113221901_initialModel', N'9.0.0');

ALTER TABLE [Clients] ADD [IsSubscribeToNewsletter] bit NOT NULL DEFAULT CAST(0 AS bit);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241113222942_AddIsSubscribeToNewsletterToCustumer', N'9.0.0');

ALTER TABLE [Clients] ADD [MembershipTypeId] tinyint NOT NULL DEFAULT CAST(0 AS tinyint);

CREATE TABLE [MembershipType] (
    [Id] tinyint NOT NULL,
    [SignUpFee] smallint NOT NULL,
    [DurationInMonths] tinyint NOT NULL,
    [DiscountRate] tinyint NOT NULL,
    CONSTRAINT [PK_MembershipType] PRIMARY KEY ([Id])
);

CREATE INDEX [IX_Clients_MembershipTypeId] ON [Clients] ([MembershipTypeId]);

ALTER TABLE [Clients] ADD CONSTRAINT [FK_Clients_MembershipType_MembershipTypeId] FOREIGN KEY ([MembershipTypeId]) REFERENCES [MembershipType] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241113223326_AddMembershipType', N'9.0.0');

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'SignUpFee', N'DurationInMonths', N'DiscountRate') AND [object_id] = OBJECT_ID(N'[MembershipType]'))
    SET IDENTITY_INSERT [MembershipType] ON;
INSERT INTO [MembershipType] ([Id], [SignUpFee], [DurationInMonths], [DiscountRate])
VALUES (CAST(1 AS tinyint), CAST(0 AS smallint), CAST(0 AS tinyint), CAST(0 AS tinyint)),
(CAST(2 AS tinyint), CAST(30 AS smallint), CAST( 1 AS tinyint), CAST(10 AS tinyint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'SignUpFee', N'DurationInMonths', N'DiscountRate') AND [object_id] = OBJECT_ID(N'[MembershipType]'))
    SET IDENTITY_INSERT [MembershipType] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241113223549_PopulateMembershipType', N'9.0.0');

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clients]') AND [c].[name] = N'Name');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Clients] DROP CONSTRAINT [' + @var0 + '];');
UPDATE [Clients] SET [Name] = N'' WHERE [Name] IS NULL;
ALTER TABLE [Clients] ALTER COLUMN [Name] nvarchar(255) NOT NULL;
ALTER TABLE [Clients] ADD DEFAULT N'' FOR [Name];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241113225401_ApplyAnnotationToCustomerName', N'9.0.0');

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'name', N'description') AND [object_id] = OBJECT_ID(N'[Outils]'))
    SET IDENTITY_INSERT [Outils] ON;
INSERT INTO [Outils] ([Id], [name], [description])
VALUES (1, N'Marteau', N'');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'name', N'description') AND [object_id] = OBJECT_ID(N'[Outils]'))
    SET IDENTITY_INSERT [Outils] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241113232441_PopulateOutils', N'9.0.0');

EXEC sp_rename N'[Outils].[name]', N'Name', 'COLUMN';

EXEC sp_rename N'[Outils].[description]', N'Description', 'COLUMN';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241115160808_OutilRename', N'9.0.0');

ALTER TABLE [MembershipType] ADD [Name] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241118143124_newNamePropertyToMembershipType', N'9.0.0');

UPDATE [MembershipType] SET [Name] = N'Particulier'
WHERE [DiscountRate] = CAST(0 AS tinyint);
SELECT @@ROWCOUNT;


UPDATE [MembershipType] SET [Name] = N'Premium'
WHERE [DiscountRate] = CAST(10 AS tinyint);
SELECT @@ROWCOUNT;


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241118143225_updateMembershipTypeWithNameProperty', N'9.0.0');

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'Email', N'DateOfBirth', N'MembershipTypeId') AND [object_id] = OBJECT_ID(N'[Clients]'))
    SET IDENTITY_INSERT [Clients] ON;
INSERT INTO [Clients] ([Id], [Name], [Email], [DateOfBirth], [MembershipTypeId])
VALUES (1, N'Francis t', N'', N'10/12/1989', CAST(1 AS tinyint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'Email', N'DateOfBirth', N'MembershipTypeId') AND [object_id] = OBJECT_ID(N'[Clients]'))
    SET IDENTITY_INSERT [Clients] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241118165516_populateClients', N'9.0.0');

EXEC sp_rename N'[MembershipType]', N'MembershipTypes', 'OBJECT';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241118173457_RenameMembershiptypeTable', N'9.0.0');

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Outils]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Outils] DROP CONSTRAINT [' + @var1 + '];');
UPDATE [Outils] SET [Name] = N'' WHERE [Name] IS NULL;
ALTER TABLE [Outils] ALTER COLUMN [Name] nvarchar(255) NOT NULL;
ALTER TABLE [Outils] ADD DEFAULT N'' FOR [Name];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241118223532_requiredNameOutil', N'9.0.0');

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241121181711_AddIdentitySupport', N'9.0.0');

COMMIT;
GO

