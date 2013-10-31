CREATE proc [dbo].[proc_top_bookinfo](@topx int = 10)
as
	select top (@topx)
		b.InfoID 
	from
		Records r join Books b on r.BookID=b.BookID
