/*Oracle*/
WITH t AS (SELECT DISTINCT visited_on FROM Customer c
WHERE visited_on >= (select min(visited_on) + interval '6' day from Customer))
SELECT to_char(t.visited_on, 'yyyy-mm-dd') visited_on, SUM(amount) amount, ROUND(SUM(amount) / 7, 2) average_amount FROM t JOIN Customer c
ON (c.visited_on >= (t.visited_on - interval '6' day) AND c.visited_on <= t.visited_on)
GROUP BY t.visited_on
ORDER BY t.visited_on
