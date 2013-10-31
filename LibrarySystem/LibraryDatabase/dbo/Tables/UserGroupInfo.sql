CREATE TABLE [dbo].[UserGroupInfo] (
    [UGID]      INT           IDENTITY (1, 1) NOT NULL,
    [GroupName] NVARCHAR (50) NOT NULL,
    [IsAdmin]   BIT           CONSTRAINT [DF_UserGroupInfo_IsAdmin] DEFAULT ((0)) NOT NULL,
    [IsVIP]     BIT           CONSTRAINT [DF_UserGroupInfo_IsVIP] DEFAULT ((0)) NOT NULL,
    [MaxOrders] INT           CONSTRAINT [DF_UserGroupInfo_MaxOrders] DEFAULT ((3)) NOT NULL,
    CONSTRAINT [PK_UserGroupInfo] PRIMARY KEY CLUSTERED ([UGID] ASC)
);

