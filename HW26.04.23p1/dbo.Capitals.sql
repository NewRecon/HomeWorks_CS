CREATE TABLE [dbo].[Capitals] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [CapitalName]      VARCHAR (100) NULL,
    [NumberOfCitizens] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

