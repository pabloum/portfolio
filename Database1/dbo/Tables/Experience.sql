CREATE TABLE [dbo].[Experience] (
    [Id]              INT             NOT NULL,
    [Company]         VARCHAR (50)    NULL,
    [Position]        VARCHAR (50)    NULL,
    [MainFunctions]   VARCHAR (MAX)   NULL,
    [Technologies]    VARCHAR (256)   NULL,
    [DateBegining]    DATETIME        NULL,
    [DateEnd]         DATETIME        NULL,
    [YearsExperience] NUMERIC (18, 2) NULL,
    CONSTRAINT [PK_Experience] PRIMARY KEY CLUSTERED ([Id] ASC)
);



