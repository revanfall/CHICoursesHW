INSERT INTO Groups (gr_id, gr_name, gr_temp)
VALUES (1, 'Group 1', 40),
       (2, 'Group 2', 2),
       (3, 'Group 3', 11),
       (4, 'Group 4', -8)

INSERT INTO Analysis (an_id, an_name, an_cost, an_price, an_group)
VALUES (1, 'Analysis 1', 10.00, 20.00, 1),
       (2, 'Analysis 2', 15.00, 30.00, 1),
       (3, 'Analysis 3', 20.00, 40.00, 2),
       (4, 'Analysis 4', 25.00, 50.00, 3),
       (5, 'Analysis 5', 30.00, 60.00, 3),
       (6, 'Analysis 6', 35.00, 70.00, 3),
       (7, 'Analysis 7', 40.00, 80.00, 4),
       (8, 'Analysis 8', 45.00, 90.00, 4)

INSERT INTO Orders (ord_id, ord_datetime, ord_an)
VALUES (1, '2020-02-05 10:30:00', 1),
       (2, '2020-02-05 11:15:00', 3),
       (3, '2020-02-15 12:00:00', 5),
       (4, '2020-02-06 13:30:00', 7),
       (5, '2020-02-08 14:45:00', 8),
       (6, '2020-03-17 09:00:00', 2),
       (7, '2020-02-14 10:30:00', 4),
       (8, '2020-02-12 12:00:00', 6)
