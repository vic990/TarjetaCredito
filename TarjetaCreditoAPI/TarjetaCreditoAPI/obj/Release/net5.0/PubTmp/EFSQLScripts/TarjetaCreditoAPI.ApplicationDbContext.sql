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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220614024156_MigracionInicial')
BEGIN
    CREATE TABLE [TarjetaCredito] (
        [Id] int NOT NULL IDENTITY,
        [Titular] Varchar(100) NOT NULL,
        [NumeroTarjeta] Varchar(16) NOT NULL,
        [FechaExpiracion] Varchar(5) NOT NULL,
        [CVV] Varchar(3) NOT NULL,
        CONSTRAINT [PK_TarjetaCredito] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220614024156_MigracionInicial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220614024156_MigracionInicial', N'5.0.1');
END;
GO

COMMIT;
GO

