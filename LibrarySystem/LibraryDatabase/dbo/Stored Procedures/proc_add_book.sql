CREATE proc [dbo].[proc_add_book](@iid bigint,@bid bigint =0 out)
as
	insert into Books
	values(@iid,default)

	set @bid=SCOPE_IDENTITY();

	update BookInfo set Total+=1,Remain+=1 where InfoID=@iid;
