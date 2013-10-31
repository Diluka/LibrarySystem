create proc proc_lease_bookinfo(@iid bigint,@uid bigint,@ld datetime)
as
	declare @bid bigint,@oid bigint;
	select top 1 @bid=BookID from Books
	where InfoID=@iid and IsLeased=0;

	if @bid is not null
	begin
		insert into Orders
		values(@uid,@bid,@ld)

		set @oid=SCOPE_IDENTITY();

		update BookInfo set Remain-=1
		where InfoID=@iid

		update Books set IsLeased=1
		where BookID=@bid

		select @oid;

		return 1;
	end

	return 0;
