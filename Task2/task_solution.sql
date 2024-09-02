USE Shop_Db;

SELECT p.Name AS ProductName, c.Name AS CategoryName
FROM Products p
     LEFT JOIN ProductCategories pc ON pc.ProductID = p.ProductId
     LEFT JOIN Categories c ON pc.CategoryID = c.CategoryId;