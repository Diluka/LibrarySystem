create proc proc_del_bookinfo(@iid bigint)
as
	delete Covers where InfoID=@iid;
	delete BookBrief where InfoID=@iid;
	delete BookInfo where InfoID=@iid;
