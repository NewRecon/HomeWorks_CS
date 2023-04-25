CREATE TABLE [dbo].[Countries] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [CountryName]      VARCHAR (100) NULL,
    [CapitalId]        INT           NULL,
    [NumberOfCitizens] INT           NULL,
    [Area]             INT           NULL,
    [ChastSveta]       VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CapitalId]) REFERENCES [dbo].[Capitals] ([Id])
);

