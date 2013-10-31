CREATE TABLE [dbo].[Records] (
    [RecordID]   BIGINT   IDENTITY (1, 1) NOT NULL,
    [UID]        BIGINT   NOT NULL,
    [BookID]     BIGINT   NOT NULL,
    [LeaseDate]  DATETIME NOT NULL,
    [ReturnDate] DATETIME CONSTRAINT [DF_Records_ReturnDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Records] PRIMARY KEY CLUSTERED ([RecordID] ASC),
    CONSTRAINT [FK_Records_Books] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Books] ([BookID]),
    CONSTRAINT [FK_Records_Users] FOREIGN KEY ([UID]) REFERENCES [dbo].[Users] ([UID])
);

