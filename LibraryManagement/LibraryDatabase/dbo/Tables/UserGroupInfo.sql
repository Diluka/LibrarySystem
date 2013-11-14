CREATE TABLE [dbo].[UserGroupInfo] (
    [GroupID]   INT           IDENTITY (1, 1) NOT NULL,
    [GroupName] NVARCHAR (50) NOT NULL,
    [IsAdmin]   BIT           CONSTRAINT [DF_UserGroupInfo_IsAdmin] DEFAULT ((0)) NOT NULL,
    [Max]       INT           CONSTRAINT [DF_UserGroupInfo_Max] DEFAULT ((3)) NOT NULL,
    CONSTRAINT [PK_UserGroupInfo] PRIMARY KEY CLUSTERED ([GroupID] ASC)
);

