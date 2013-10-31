CREATE proc [dbo].[proc_pre_into_order](@pid bigint,@ld datetime,@oid bigint out)
as
	declare @iid bigint,@uid bigint,@bid bigint;

	select @uid=[UID],@iid=InfoID from PreOrders
	where @pid=PreOrderID

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

		delete PreOrders
		where @pid=PreOrderID

		return 1;
	end

	return 0;
