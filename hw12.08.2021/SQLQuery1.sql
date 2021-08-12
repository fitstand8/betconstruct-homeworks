use TSQLV4;
select top(10) custid, count(*) as orders_count
from Sales.Orders
group by custid
having count(*) > (select avg(counts) from (select custid, count(*) as counts from Sales.Orders group by custid)as a)
order by orders_count desc;

