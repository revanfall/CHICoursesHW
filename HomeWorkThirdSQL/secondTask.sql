SELECT orderYear, orderMonth, gr_name, sold, SUM(sold) OVER (PARTITION BY gr_name ORDER BY orderYear, orderMonth) AS soldChanges
FROM (
    SELECT YEAR(ord_datetime)  AS orderYear, MONTH(ord_datetime) AS orderMonth, gr_name, COUNT(*) AS sold
    FROM Orders o
    JOIN Analysis a ON o.ord_an = a.an_id
    JOIN Groups g ON a.an_group = g.gr_id
    GROUP BY YEAR(ord_datetime), MONTH(ord_datetime), gr_name
) t;