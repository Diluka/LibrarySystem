CREATE TABLE [dbo].[Books] (
    [BookID]   BIGINT IDENTITY (1, 1) NOT NULL,
    [InfoID]   BIGINT NOT NULL,
    [IsLeased] BIT    CONSTRAINT [DF_Books_IsLeased] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([BookID] ASC),
    CONSTRAINT [FK_Books_BookInfo] FOREIGN KEY ([InfoID]) REFERENCES [dbo].[BookInfo] ([InfoID])
);


GO
create trigger tgr_update_total_and_remain
on books
for insert,update,delete
as
	if (select count(*) from deleted) is not null
	begin
		update BookInfo set Total-=1,Remain-=1
		where InfoID=(select InfoID from deleted)
	end

	if (select count(*) from inserted) is not null
	begin
		update BookInfo set Total+=1,Remain+=1
		where InfoID=(select InfoID from inserted)
	end
