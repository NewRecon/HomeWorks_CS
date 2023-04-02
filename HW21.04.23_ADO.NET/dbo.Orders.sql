CREATE TABLE [dbo].[Orders] (
    [Id]             INT  IDENTITY (1, 1) NOT NULL,
    [ProductsId]     INT  NOT NULL,
    [ProductsTypeId] INT  NOT NULL,
    [ProvidersId]    INT  NOT NULL,
    [ProductCount]   INT  NOT NULL,
    [Price]          INT  NOT NULL,
    [DeliveryDate]   DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ProductsTypeId]) REFERENCES [dbo].[ProductsType] ([Id]),
    FOREIGN KEY ([ProvidersId]) REFERENCES [dbo].[Providers] ([Id]),
    FOREIGN KEY ([ProductsId]) REFERENCES [dbo].[Products] ([Id])
);

