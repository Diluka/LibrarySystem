CREATE VIEW [dbo].[OrderView]
	AS 
	SELECT 
		Orders.OrderID AS 订单号,
		Orders.BookID AS 书本编号,
		Orders.UID AS 用户ID,
		BookInfo.Title AS 标题,
		Authors.AuthorName AS 作者,
		Orders.LeaseDate AS 借出日期
	FROM 
		Orders 
		JOIN Books ON Orders.BookID=Books.BookID
		JOIN BookInfo ON BookInfo.InfoID=Books.InfoID
		JOIN Authors ON Authors.AuthorID=BookInfo.AuthorID
