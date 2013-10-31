CREATE TABLE [dbo].[UserInfo] (
    [UID]     BIGINT         NOT NULL,
    [Name]    NVARCHAR (50)  NOT NULL,
    [Age]     INT            NULL,
    [Gender]  BIT            NULL,
    [Phone]   VARCHAR (50)   NULL,
    [Email]   VARCHAR (200)  NULL,
    [Address] NVARCHAR (200) NULL,
    [RegTime] DATETIME       CONSTRAINT [DF_UserInfo_RegTime] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED ([UID] ASC),
    CONSTRAINT [FK_UserInfo_Users] FOREIGN KEY ([UID]) REFERENCES [dbo].[Users] ([UID])
);

