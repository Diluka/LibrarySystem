CREATE VIEW [dbo].[BookView]
	AS
	SELECT 
		[dbo].[Books].[BookID] AS 书本编号, [dbo].[BookInfo].[Title] AS 标题,[dbo].[Authors].[AuthorName] AS 作者,[dbo].[Presses].[PressName] AS 出版社,[dbo].[BookInfo].[Remain] AS 现库存
	FROM 
		[dbo].[Books] JOIN [dbo].[BookInfo] ON [dbo].[Books].[InfoID]=[dbo].[BookInfo].[InfoID]
		LEFT JOIN [dbo].[Authors] ON [dbo].[BookInfo].[AuthorID]=[dbo].[Authors].[AuthorID]
		LEFT JOIN [dbo].[Presses] ON [dbo].[BookInfo].[PressID]=[dbo].[Presses].[PressID]
