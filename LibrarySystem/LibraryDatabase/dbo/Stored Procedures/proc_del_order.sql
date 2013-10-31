CREATE proc [dbo].[proc_del_order](@oid bigint)
as
	update BookInfo set Remain+=1 
	where InfoID=(select InfoID from Books 
		where BookID=(select BookID from Orders 
			where OrderID=@oid))

	update Books set IsLeased=0 
	where BookID=(select BookID from Orders 
		where OrderID=@oid)

	delete Orders where OrderID=@oid
