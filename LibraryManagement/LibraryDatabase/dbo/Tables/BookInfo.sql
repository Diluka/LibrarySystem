CREATE TABLE [dbo].[BookInfo] (
    [BookInfoID]  INT           IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (50) NOT NULL,
    [ISBN]        CHAR (13)     NULL,
    [Author]      NVARCHAR (50) NULL,
    [Press]       NVARCHAR (50) NULL,
    [Category]    NVARCHAR (50) NULL,
    [Price]       MONEY         NULL,
    [PublishDate] DATETIME      NULL,
    [Brief]       TEXT          NULL,
    [Cover]       IMAGE         NULL,
    CONSTRAINT [PK_BookInfo] PRIMARY KEY CLUSTERED ([BookInfoID] ASC),
    CONSTRAINT [FK_BookInfo_Authors] FOREIGN KEY ([Author]) REFERENCES [dbo].[Author] ([AuthorName]),
    CONSTRAINT [FK_BookInfo_Categories] FOREIGN KEY ([Category]) REFERENCES [dbo].[Category] ([CategoryName]),
    CONSTRAINT [FK_BookInfo_Presses] FOREIGN KEY ([Press]) REFERENCES [dbo].[Press] ([PressName])
);

