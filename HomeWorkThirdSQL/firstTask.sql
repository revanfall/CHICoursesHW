SELECT an_name, an_price
FROM Orders o
JOIN Analysis a ON o.ord_an = a.an_id
WHERE ord_datetime BETWEEN '2020-02-05' AND '2020-02-12'