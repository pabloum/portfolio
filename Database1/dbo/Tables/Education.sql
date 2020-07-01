CREATE TABLE [dbo].[Education] (
    [Id]           INT           NOT NULL,
    [University]   VARCHAR (50)  NULL,
    [Title]        VARCHAR (50)  NULL,
    [DateBegining] DATETIME      NULL,
    [DateEnd]      DATETIME      NULL,
    [Description]  VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED ([Id] ASC)
);

