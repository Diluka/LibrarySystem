CREATE TABLE [dbo].[Category] (
    [CategoryName] NVARCHAR (50) NOT NULL,
    [MaxDay]       INT           CONSTRAINT [DF_Categories_MaxDay] DEFAULT ((30)) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryName] ASC)
);

