CREATE TABLE [dbo].[VegetablesAndFruits] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (100) NOT NULL,
    [Color]    VARCHAR (100) NOT NULL,
    [Calories] INT           NOT NULL,
    [Type]     VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

