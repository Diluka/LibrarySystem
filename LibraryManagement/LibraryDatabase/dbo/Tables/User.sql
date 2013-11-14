CREATE TABLE [dbo].[User] (
    [UserID]      INT            IDENTITY (1, 1) NOT NULL,
    [UserName]    VARCHAR (50)   NOT NULL,
    [UserPWD]     CHAR (40)      NOT NULL,
    [UserGroupID] INT            NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Age]         INT            NULL,
    [Gender]      NCHAR (1)      NULL,
    [Phone]       VARCHAR (50)   NULL,
    [Email]       VARCHAR (200)  NULL,
    [Address]     NVARCHAR (200) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Users_UserGroupInfo] FOREIGN KEY ([UserGroupID]) REFERENCES [dbo].[UserGroupInfo] ([GroupID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users]
    ON [dbo].[User]([UserName] ASC);

