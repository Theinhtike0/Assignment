IF EXISTS (SELECT * FROM sys.objects 
           WHERE type = 'P' AND name = 'UP_CREATE_PRODUCT')
BEGIN
    DROP PROCEDURE [dbo].[UP_CREATE_PRODUCT]
END
GO
CREATE PROCEDURE [dbo].[UP_CREATE_PRODUCT]
    @ProductName NVARCHAR(100),
    @Description NVARCHAR(100),
    @Price DECIMAL(10,2),
    @CreatedAt DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @CreatedAt IS NULL
        SET @CreatedAt = GETDATE();
    INSERT INTO dbo.Products (ProductName, Description, Price, CreatedAt)
    VALUES (@ProductName, @Description, @Price, @CreatedAt);
    SELECT SCOPE_IDENTITY() AS NewProductId;
END
GO
------------------------------------------------------------------
IF EXISTS (SELECT * FROM sys.objects 
           WHERE type = 'P' AND name = 'UP_UPDATE_PRODUCT')
BEGIN
    DROP PROCEDURE [dbo].[UP_UPDATE_PRODUCT]
END
GO
CREATE    PROCEDURE [DBO].[UP_UPDATE_PRODUCT]  
    @Id INT,    
    @ProductName NVARCHAR(100),    
    @Description NVARCHAR(MAX),    
    @Price DECIMAL(10,2) 
AS    
BEGIN    
    UPDATE Products     
    SET     
        ProductName = @ProductName,    
        Description = @Description,    
        Price = @Price    
    WHERE     
        Id = @Id    
            
    RETURN @@ROWCOUNT    
END
GO
-------------------------------------------------------------------
IF EXISTS (SELECT * FROM sys.objects 
           WHERE type = 'P' AND name = 'UP_DELETE_PRODUCT')
BEGIN
    DROP PROCEDURE [dbo].[UP_DELETE_PRODUCT]
END
GO
CREATE    PROCEDURE [DBO].[UP_DELETE_PRODUCT]      
   @Id int            
        
AS    
BEGIN         
        
 delete from Products where Id=@Id     
      
END
GO
-------------------------------------------------------------------
IF EXISTS (SELECT * FROM sys.objects 
           WHERE type = 'P' AND name = 'UP_GET_PRODUCTID')
BEGIN
    DROP PROCEDURE [dbo].[UP_GET_PRODUCTID]
END
GO
CREATE    PROCEDURE [DBO].[UP_GET_PRODUCTID]  
    @Id INT    
AS    
BEGIN    
    SELECT * FROM Products WHERE Id = @Id    
END
GO
-------------------------------------------------------------------
IF EXISTS (SELECT * FROM sys.objects 
           WHERE type = 'P' AND name = 'UP_GET_PRODUCT')
BEGIN
    DROP PROCEDURE [dbo].[UP_GET_PRODUCT]
END
GO
CREATE     PROCEDURE [DBO].[UP_GET_PRODUCT]  
AS      
BEGIN      
    SELECT * FROM Products       
END
GO
----------------------------------------------------------------