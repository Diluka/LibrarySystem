CREATE TABLE [dbo].[Orders] (
    [OrderID]   BIGINT   IDENTITY (1, 1) NOT NULL,
    [UID]       BIGINT   NOT NULL,
    [BookID]    BIGINT   NOT NULL,
    [LeaseDate] DATETIME CONSTRAINT [DF_Orders_OrderDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Orders_Books] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Books] ([BookID]),
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UID]) REFERENCES [dbo].[Users] ([UID])
);

