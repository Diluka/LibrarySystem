create proc proc_add_pre(@uid bigint,@iid bigint,@pid bigint =0 out)
as
	insert into PreOrders
	values(@uid,@iid,default)

	set @pid=SCOPE_IDENTITY()
	select @pid;
