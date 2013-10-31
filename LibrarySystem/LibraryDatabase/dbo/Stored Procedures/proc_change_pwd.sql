create proc proc_change_pwd(@uid bigint,@pw varchar(50))
as
	declare @pwe char(40);
	select @pwe=CONVERT(char(40),hashbytes('SHA1',@pw),2);

	update Users set Password=@pwe where [UID]=@uid;
