CREATE proc [dbo].[proc_return_book](@id bigint,@rd datetime,@rid bigint out)
as
	if(exists(select * from Orders where BookID=@id))
	begin
		declare @uid bigint,@bid bigint,@ld datetime,@oid bigint;

		select
			@oid=OrderID,
			@uid=[UID],
			@bid=BookID,
			@ld=LeaseDate
		from Orders where BookID=@id

		insert into
			Records
		values(@uid,@bid,@ld,@rd)

		set @rid=SCOPE_IDENTITY();

		exec proc_del_order @oid;

		return 1;
	end
	return 0;
