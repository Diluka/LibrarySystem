create proc proc_del_bookinfo(@iid bigint)
as
	declare @bid bigint;

	select top 1 @bid=BookID from Books where Books.InfoID=@iid;
	while(@bid is not null)
	begin
		exec proc_del_book @bid;
		select top 1 @bid=BookID from Books where Books.InfoID=@iid;
	end

	delete Covers where InfoID=@iid;
	delete BookBrief where InfoID=@iid;
	delete BookInfo where InfoID=@iid;
