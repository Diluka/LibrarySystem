CREATE proc [dbo].[proc_lease_book](@uid bigint,@bid bigint,@ld datetime,@oid bigint out)
as
begin
	if (select IsLeased from Books where @bid=BookID)=0
	AND (select count(*) from Orders where @uid=[UID])<(select MaxOrders from UserGroupInfo where UGID=(select UserGroupID from users where @uid=[uid]))
	begin
		insert into Orders
		values(@uid,@bid,@ld)

		set @oid=SCOPE_IDENTITY();

		update Books set IsLeased=1
		where BookID=@bid

		update BookInfo set Remain-=1
		where InfoID=(select InfoID from Books where BookID=@bid)

		return 1;
	end
	return 0;
end
