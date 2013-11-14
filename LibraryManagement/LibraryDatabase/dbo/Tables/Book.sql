CREATE TABLE [dbo].[Book] (
    [BookID]     INT           IDENTITY (1, 1) NOT NULL,
    [BookInfoID] INT           NOT NULL,
    [IsRent]     BIT           NOT NULL,
    [Remark]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([BookID] ASC),
    CONSTRAINT [FK_Books_BookInfo] FOREIGN KEY ([BookInfoID]) REFERENCES [dbo].[BookInfo] ([BookInfoID])
);

