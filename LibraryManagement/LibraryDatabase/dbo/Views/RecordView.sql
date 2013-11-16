CREATE VIEW dbo.RecordView
AS
SELECT   dbo.Record.RecordID AS 订单编号, dbo.Record.UserID AS 用户编号, dbo.Record.BookID AS 藏书号, 
                dbo.[User].UserName AS 账户, dbo.BookInfo.Title AS 标题, dbo.BookInfo.Author AS 作者, dbo.[User].Name AS 用户姓名, 
                dbo.Record.OutDate AS 借出日期, dbo.Record.ReturnDate AS 归还日期, dbo.Category.CategoryName AS 类别, 
                dbo.Category.MaxDay AS 最大天数, DATEDIFF(D, dbo.Record.OutDate, ISNULL(dbo.Record.ReturnDate, GETDATE())) 
                AS 借阅天数
FROM      dbo.Record INNER JOIN
                dbo.[User] ON dbo.Record.UserID = dbo.[User].UserID INNER JOIN
                dbo.Book ON dbo.Record.BookID = dbo.Book.BookID INNER JOIN
                dbo.BookInfo ON dbo.Book.BookInfoID = dbo.BookInfo.BookInfoID LEFT JOIN
                dbo.Category ON dbo.BookInfo.Category = dbo.Category.CategoryName
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[17] 2[24] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Record"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 145
               Right = 192
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 6
               Left = 230
               Bottom = 136
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Book"
            Begin Extent = 
               Top = 6
               Left = 434
               Bottom = 145
               Right = 590
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BookInfo"
            Begin Extent = 
               Top = 6
               Left = 628
               Bottom = 145
               Right = 785
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "Category"
            Begin Extent = 
               Top = 150
               Left = 38
               Bottom = 251
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'RecordView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'RecordView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'RecordView';

