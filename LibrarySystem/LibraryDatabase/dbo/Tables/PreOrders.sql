CREATE TABLE [dbo].[PreOrders] (
    [PreOrderID]   BIGINT   IDENTITY (1, 1) NOT NULL,
    [UID]          BIGINT   NOT NULL,
    [InfoID]       BIGINT   NOT NULL,
    [PreOrderDate] DATETIME CONSTRAINT [DF_PreOrders_PreOrderDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_PreOrders] PRIMARY KEY CLUSTERED ([PreOrderID] ASC),
    CONSTRAINT [FK_PreOrders_BookInfo] FOREIGN KEY ([InfoID]) REFERENCES [dbo].[BookInfo] ([InfoID]),
    CONSTRAINT [FK_PreOrders_Users] FOREIGN KEY ([UID]) REFERENCES [dbo].[Users] ([UID])
);

