CREATE PROCEDURE [dbo].[proc_del_author]
	@aid int
AS
	UPDATE BookInfo SET AuthorID = NULL WHERE AuthorID = @aid;
	DELETE Authors WHERE AuthorID = @aid;
RETURN 0
