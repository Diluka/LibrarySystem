CREATE TABLE [dbo].[BookInfo] (
    [InfoID]    BIGINT         IDENTITY (1, 1) NOT NULL,
    [CatID]     INT            NULL,
    [Title]     NVARCHAR (100) NOT NULL,
    [Alphabet]  CHAR (1)       NOT NULL,
    [ISBN]      CHAR (13)      NULL,
    [AuthorID]  INT            NULL,
    [PressID]   INT            NULL,
    [PressDate] DATETIME       NULL,
    [Price]     MONEY          NULL,
    [Total]     INT            CONSTRAINT [DF_BookInfo_Total] DEFAULT ((0)) NOT NULL,
    [Remain]    INT            CONSTRAINT [DF_BookInfo_Remain] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_BookInfo] PRIMARY KEY CLUSTERED ([InfoID] ASC),
    CONSTRAINT [FK_BookInfo_Authors] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Authors] ([AuthorID]),
    CONSTRAINT [FK_BookInfo_Categories] FOREIGN KEY ([CatID]) REFERENCES [dbo].[Categories] ([CatID]),
    CONSTRAINT [FK_BookInfo_Presses] FOREIGN KEY ([PressID]) REFERENCES [dbo].[Presses] ([PressID])
);

