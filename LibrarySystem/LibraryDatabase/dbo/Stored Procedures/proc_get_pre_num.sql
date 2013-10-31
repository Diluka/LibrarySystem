create proc proc_get_pre_num(@iid bigint,@num int =0 out)
as
	select @num=count(*) from PreOrders
	where InfoID=@iid

	set @num=ISNULL(@num,0);

	return @num;
