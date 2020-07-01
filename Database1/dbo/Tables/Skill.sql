CREATE TABLE [dbo].[Skill] (
    [Id]         INT          NOT NULL,
    [Name]       VARCHAR (50) NULL,
    [Category]   INT          NULL,
    [Percentage] INT          NULL,
    CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED ([Id] ASC)
);

