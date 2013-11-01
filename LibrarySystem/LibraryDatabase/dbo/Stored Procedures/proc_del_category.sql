CREATE PROCEDURE [dbo].[proc_del_category]
	@cid int
AS
	UPDATE BookInfo SET CatID = NULL WHERE CatID = @cid;
	DELETE Categories WHERE CatID = @cid;
RETURN 0
