SELECT C.CategoryName, COUNT(p.ProductID) AS discontinued_products_number FROM Products p
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.Discontinued = 1
GROUP BY c.CategoryName
HAVING COUNT(p.ProductID) >= 3
ORDER BY discontinued_products_number DESC



SELECT 
*
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