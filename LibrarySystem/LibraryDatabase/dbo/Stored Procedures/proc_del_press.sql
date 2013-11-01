CREATE PROCEDURE [dbo].[proc_del_press]
	@pid int
AS
	UPDATE BookInfo SET PressID = NULL WHERE PressID = @pid;
	DELETE Presses WHERE PressID = @pid;
RETURN 0
