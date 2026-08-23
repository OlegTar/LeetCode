select id1 id, count(*) num from (
    select requester_id id1, accepter_id id2 from RequestAccepted 
    union
    select accepter_id, requester_id from RequestAccepted
) t group by id1
order by num desc
limit 1;
