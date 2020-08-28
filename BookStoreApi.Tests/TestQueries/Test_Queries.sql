INSERT INTO shop.author
(id,first_name, last_name)
VALUES
(1,'William', 'Shakespeare'),
(2,'Aghata', 'Christie'),
(3,'Edwin', 'Abbott'),
(4,'Barbara', 'Cartland'),
(5,'Stephen', 'King');

INSERT INTO shop.book
(id,title, author_id, price)
VALUES
(1,'Romeo and Juliet',1,30.00),
(2,'Murder on the Orient Express', 2, 25.00),
(3,'Flatland', 3, 35.00),
(4,'The Cossacks', 4, 28.00),
(5,'IT', 5, 32.00);

INSERT INTO shop.customer
(id,first_name, last_name, mail, phone_number, city)
VALUES
(1,'Ewelina', 'Pawlowska', 'e.pawlowska@gmail.com', '654-123-098', 'Krakow'),
(2,'Sylwia', 'Maslak', 's.maslak@gmail.com', '546-234-756', 'Wroclaw'),
(3,'Mariusz', 'Gorac', 'm.gorac@gmail.com', '576-075-473', 'Warszawa');

INSERT INTO shop.shop_order
(id,customer_id)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 1);

INSERT INTO shop.order_book
(order_id, book_id)
VALUES
(1, 1), (1, 5), (1, 5),
(2, 4),
(3, 4),
(4, 2);

SELECT setval('shop.author_id_seq', 5, true);
SELECT setval('shop.book_id_seq', 5, true);
SELECT setval('shop.customer_id_seq', 3, true);
SELECT setval('shop.order_id_seq', 4, true);
