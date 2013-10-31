CREATE TABLE [dbo].[Categories] (
    [CatID]    INT           IDENTITY (1, 1) NOT NULL,
    [Category] NVARCHAR (50) NOT NULL,
    [MaxDay]   INT           CONSTRAINT [DF_Categories_MaxDay] DEFAULT ((30)) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CatID] ASC)
);

