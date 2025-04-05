
IF EXISTS (SELECT * FROM sys.objects 
           WHERE type = 'U' AND name = 'Products')
BEGIN
    DROP TABLE [dbo].[Products]
END
GO

CREATE TABLE [dbo].[Products]
(
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ProductName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(100) NULL,
    [Price] DECIMAL(10,2) NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE()
)
GO


