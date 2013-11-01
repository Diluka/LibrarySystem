CREATE VIEW dbo.BookMgrView
AS
SELECT   dbo.BookInfo.InfoID AS 书籍编号, dbo.BookInfo.Title AS 书籍标题, dbo.BookInfo.Alphabet AS 首字母, dbo.BookInfo.ISBN, 
                dbo.Authors.AuthorName AS 作者, dbo.Presses.PressName AS 出版社, dbo.BookInfo.PressDate AS 出版日期, 
                dbo.BookInfo.Price AS 单价, dbo.Categories.Category AS 分类, dbo.Categories.MaxDay AS 最大天数, 
                dbo.BookInfo.Total AS 总数, dbo.BookInfo.Remain AS 剩余库存
FROM      dbo.BookInfo LEFT JOIN
                dbo.Categories ON dbo.BookInfo.CatID = dbo.Categories.CatID LEFT JOIN
                dbo.Authors ON dbo.BookInfo.AuthorID = dbo.Authors.AuthorID LEFT JOIN
                dbo.Presses ON dbo.BookInfo.PressID = dbo.Presses.PressID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "BookInfo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 145
               Right = 185
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "Categories"
            Begin Extent = 
               Top = 6
               Left = 223
               Bottom = 126
               Right = 365
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Authors"
            Begin Extent = 
               Top = 6
               Left = 403
               Bottom = 107
               Right = 566
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Presses"
            Begin Extent = 
               Top = 6
               Left = 604
               Bottom = 107
               Right = 759
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
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'BookMgrView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'BookMgrView';

