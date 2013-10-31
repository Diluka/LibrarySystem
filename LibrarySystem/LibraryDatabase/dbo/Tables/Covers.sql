CREATE TABLE [dbo].[Covers] (
    [InfoID]     BIGINT NOT NULL,
    [CoverImage] IMAGE  NOT NULL,
    CONSTRAINT [PK_Covers] PRIMARY KEY CLUSTERED ([InfoID] ASC),
    CONSTRAINT [FK_Covers_BookInfo] FOREIGN KEY ([InfoID]) REFERENCES [dbo].[BookInfo] ([InfoID])
);

