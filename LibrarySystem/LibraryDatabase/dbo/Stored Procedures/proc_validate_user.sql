create proc proc_validate_user(@uid bigint,@password varchar(50),@validate bit out)
as
	declare @pw char(40),@pwe char(40);
	select @pw=[Password] from Users where [UID]=@uid;

	select @pwe=CONVERT(char(40),hashbytes('SHA1',@password),2);

	if(@pw=@pwe)
		set @validate=1;
	else
		set @validate=0;
	
