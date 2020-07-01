CREATE TABLE [dbo].[Project] (
    [Id]           INT           NOT NULL,
    [ProjectName]  VARCHAR (50)  NULL,
    [Technologies] VARCHAR (256) NULL,
    [Description]  VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([Id] ASC)
);

