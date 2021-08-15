use TSQLV4;

--Exercise 1
select Sales.Customers.custid, Sales.Customers.contactname, Sales.Orders.orderid, Sales.Orders.orderdate 
from Sales.Customers
left join Sales.Orders on Sales.Customers.custid = Sales.Orders.custid;


--Exercise 2 method 1
select Sales.Customers.custid, Sales.Customers.contactname, Sales.Orders.orderid, Sales.Orders.orderdate 
from Sales.Customers
join Sales.Orders on Sales.Customers.custid = Sales.Orders.custid
where Sales.Orders.orderdate = '2016-02-12';


--Exercise 2 method 2
select Sales.Customers.custid, Sales.Customers.contactname, Sales.Orders.orderid, Sales.Orders.orderdate 
from Sales.Customers
join Sales.Orders on Sales.Customers.custid = Sales.Orders.custid and Sales.Orders.orderdate = '2016-02-12';