CREATE TABLE [dbo].[Books] (
    [BookID]   BIGINT IDENTITY (1, 1) NOT NULL,
    [InfoID]   BIGINT NOT NULL,
    [IsLeased] BIT    CONSTRAINT [DF_Books_IsLeased] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([BookID] ASC),
    CONSTRAINT [FK_Books_BookInfo] FOREIGN KEY ([InfoID]) REFERENCES [dbo].[BookInfo] ([InfoID])
);


GO
