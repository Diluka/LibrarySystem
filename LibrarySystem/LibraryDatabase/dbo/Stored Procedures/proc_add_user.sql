CREATE proc [dbo].[proc_add_user](@un varchar(50),@pw varchar(50),@gid int=0,@id bigint out)
as
	declare @pwe char(40);
	select @pwe=CONVERT(char(40),hashbytes('SHA1',@pw),2);

	insert into Users
	Values(@un,@pwe,@gid)

	set @id=SCOPE_IDENTITY();
