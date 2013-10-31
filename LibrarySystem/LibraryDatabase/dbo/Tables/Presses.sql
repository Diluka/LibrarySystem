CREATE TABLE [dbo].[Presses] (
    [PressID]   INT           IDENTITY (1, 1) NOT NULL,
    [PressName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Presses] PRIMARY KEY CLUSTERED ([PressID] ASC)
);

