SELECT C.CategoryName, COUNT(p.ProductID) AS discontinued_products_number FROM Products p
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.Discontinued = 1
GROUP BY c.CategoryName
HAVING COUNT(p.ProductID) >= 3
ORDER BY discontinued_products_number DESC



SELECT 
c.ContactName,
c.ContactTitle,
p.ProductName,
od.UnitPrice
FROM Customers c
LEFT JOIN Orders o
	ON o.CustomerID = c.CustomerID
LEFT JOIN [Order Details] od
	ON od.OrderID = o.OrderID
LEFT JOIN Products p
	ON od.ProductID = p.ProductID
WHERE c.ContactName IS NULL 
OR c.ContactTitle IS NULL
OR p.ProductName IS NULL
OR od.UnitPrice IS NULL



SELECT 
c.ContactName,
COUNT(1) AS Purchase_Quantity
FROM Orders o
JOIN Customers c
	ON o.CustomerID = c.CustomerID
JOIN [Order Details] od
	ON od.OrderID = o.OrderID
WHERE O.ShipCity IS NOT NULL
GROUP BY c.ContactName
HAVING SUM((od.Quantity * od.UnitPrice)) > 14
ORDER BY Purchase_Quantity DESC



WITH ProductSales AS (
    SELECT p.ProductID, p.ProductName, c.CategoryName, SUM(od.Quantity) AS TotalQuantity
    FROM Products p
    JOIN [Order Details] od ON p.ProductID = od.ProductID
    JOIN Categories c ON p.CategoryID = c.CategoryID
    GROUP BY p.ProductID, p.ProductName, c.CategoryName
)
SELECT ps.CategoryName, ps.ProductName, ps.TotalQuantity
FROM ProductSales ps
JOIN (
    SELECT CategoryName, MAX(TotalQuantity) AS MaxQuantity
    FROM ProductSales
    GROUP BY CategoryName
) maxSales ON ps.CategoryName = maxSales.CategoryName AND ps.TotalQuantity = maxSales.MaxQuantity;



SELECT c.CustomerID, c.CompanyName
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.CompanyName
HAVING COUNT(DISTINCT YEAR(o.OrderDate)) = (SELECT COUNT(DISTINCT YEAR(OrderDate)) FROM Orders);




WITH OrderDates AS (
    SELECT CustomerID, OrderDate,
           LAG(OrderDate) OVER (PARTITION BY CustomerID ORDER BY OrderDate) AS PreviousOrderDate
    FROM Orders
)
SELECT CustomerID, AVG(DATEDIFF(day, PreviousOrderDate, OrderDate)) AS AvgDaysBetweenOrders
FROM OrderDates
WHERE PreviousOrderDate IS NOT NULL
GROUP BY CustomerID;




WITH CategoryAverages AS (
    SELECT CategoryID, AVG(od.Quantity * od.UnitPrice) AS AvgSales
    FROM Products p
    JOIN [Order Details] od ON p.ProductID = od.ProductID
    GROUP BY CategoryID
)
SELECT p.ProductName, c.CategoryName, SUM(od.Quantity * od.UnitPrice) AS TotalSales
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY p.ProductName, c.CategoryName, p.CategoryID
HAVING SUM(od.Quantity * od.UnitPrice) > (SELECT AvgSales FROM CategoryAverages WHERE CategoryAverages.CategoryID = p.CategoryID);




WITH EmployeeSales AS (
    SELECT e.EmployeeID, e.FirstName, e.LastName, SUM(od.Quantity * od.UnitPrice) AS TotalSales
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY e.EmployeeID, e.FirstName, e.LastName
)
SELECT es.FirstName, es.LastName, es.TotalSales
FROM EmployeeSales es
WHERE es.TotalSales > (SELECT AVG(TotalSales) FROM EmployeeSales);


--##################################################################################################################################################################################################


SELECT c.CustomerID, COUNT(1) AS OrdersQuantity
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE MONTH(o.OrderDate) = MONTH('1996-07-04 00:00:00.000') AND YEAR(o.OrderDate) = YEAR('1996-07-04 00:00:00.000')
GROUP BY c.CustomerID
ORDER BY OrdersQuantity DESC


SELECT ProductName, (UnitPrice * UnitsInStock) AS ProfitMargin FROM Products ORDER BY ProfitMargin ASC


SELECT * FROM Orders WHERE OrderID IN (SELECT o.OrderID
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY o.OrderID
HAVING COUNT(DISTINCT c.CategoryID) > 1)


SELECT * FROM Customers c
WHERE CustomerID NOT IN (SELECT CustomerID FROM Orders WHERE YEAR(OrderDate) = YEAR((SELECT TOP 1 OrderDate FROM Orders ORDER BY OrderDate DESC)) - 1)



SELECT YEAR(o.OrderDate) AS Year, MONTH(o.OrderDate) AS Month, SUM(od.UnitPrice) AS Sales FROM [Order Details] od
JOIN Orders o ON od.OrderID = o.OrderID
GROUP BY MONTH(o.OrderDate), YEAR(o.OrderDate)
ORDER BY Year DESC, Month DESC
