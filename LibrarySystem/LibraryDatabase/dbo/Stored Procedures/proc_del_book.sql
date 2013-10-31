create proc proc_del_book(@bid bigint)
as
	if (select IsLeased from Books where BookID=@bid)=0
	begin
		update BookInfo set Total-=1,Remain-=1 where InfoID=(select InfoID from Books where BookID=@bid)

		delete Books where BookID=@bid

		return 1;
	end
	else
		return 0;
