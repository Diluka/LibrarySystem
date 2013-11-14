CREATE TABLE [dbo].[Record] (
    [RecordID]   INT           NOT NULL,
    [UserID]     INT           NOT NULL,
    [BookID]     INT           NOT NULL,
    [OutDate]    DATETIME      NOT NULL,
    [ReturnDate] DATETIME      NULL,
    [Remark]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Records] PRIMARY KEY CLUSTERED ([RecordID] ASC),
    CONSTRAINT [FK_Records_Books] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Book] ([BookID]),
    CONSTRAINT [FK_Records_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID])
);

