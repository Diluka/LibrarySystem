CREATE TABLE [dbo].[BookBrief] (
    [InfoID]    BIGINT NOT NULL,
    [BriefText] NTEXT  NOT NULL,
    CONSTRAINT [PK_BookBrief] PRIMARY KEY CLUSTERED ([InfoID] ASC),
    CONSTRAINT [FK_BookBrief_BookInfo] FOREIGN KEY ([InfoID]) REFERENCES [dbo].[BookInfo] ([InfoID])
);

