CREATE TABLE [dbo].[Cities] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [CityName]         VARCHAR (100) NULL,
    [NumberOfCitizens] INT           NULL,
    [CountrieId]       INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CountrieId]) REFERENCES [dbo].[Countries] ([Id])
);

