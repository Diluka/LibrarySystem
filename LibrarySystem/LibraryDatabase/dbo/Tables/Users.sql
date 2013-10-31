CREATE TABLE [dbo].[Users] (
    [UID]         BIGINT       IDENTITY (10000, 1) NOT NULL,
    [Username]    VARCHAR (50) NOT NULL,
    [Password]    CHAR (40)    NOT NULL,
    [UserGroupID] INT          CONSTRAINT [DF_Users_Auth] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UID] ASC),
    CONSTRAINT [FK_Users_UserGroupInfo] FOREIGN KEY ([UserGroupID]) REFERENCES [dbo].[UserGroupInfo] ([UGID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users]
    ON [dbo].[Users]([Username] ASC);

