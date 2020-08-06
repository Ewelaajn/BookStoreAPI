-- CREATE TABLE shop.customer 
-- (
-- 	id SERIAL PRIMARY KEY,
-- 	first_name TEXT,
-- 	last_name TEXT,
-- 	mail TEXT,
-- 	phone_number INTEGER,
-- 	city TEXT
-- );

-- CREATE TABLE shop.author
-- (
-- 	id SERIAL PRIMARY KEY,
-- 	first_name TEXT,
-- 	last_name TEXT
-- );

-- CREATE TABLE shop.book
-- (
-- 	id SERIAL PRIMARY KEY,
-- 	title TEXT,
-- 	author_id INT REFERENCES shop.author(id),
-- 	price DECIMAL(4,2)
-- );

-- CREATE TABLE shop.order
-- (
-- 	id SERIAL PRIMARY KEY,
-- 	is_active BOOL DEFAULT TRUE,
-- 	order_time TIMESTAMP DEFAULT NOW(),
-- 	customer_id INTEGER REFERENCES shop.customer(id)
-- );

-- CREATE TABLE shop.order_book
-- (
-- 	order_id INTEGER REFERENCES shop.order(id),
-- 	book_id INTEGER REFERENCES shop.book(id)
-- );

INSERT INTO shop.author
(first_name, last_name)
VALUES
('J.K.', 'Rowling'),
('Sidney', 'Sheldon'),
('Gilbert', 'Patten'),
('Dr.', 'Seuss'),
('Leo', 'Tolstoy');

INSERT INTO shop.customer
(first_name, last_name, mail, phone_number, city)
VALUES
('Martyna', 'Nowacka', 'm.nowacka@gmail.com', 647937495, 'Katowice'),
('Eugeniusz', 'Rak', 'e.rak@o2.pl', 583920475, 'Wrocław'),
('Artur', 'Majchrzak', 'a.majchrzak@gmail.com', 666478394, 'Oława');

INSERT INTO shop.book
(title, author_id, price)
VALUES
(' Harry Potter and the Philosophers Stone', 1, 34.99),
('Master of the Game', 2, 24.99),
('Bloodline', 2, 19.99),
('Poem', 3, 14.99),
('hidwick The Big-Hearted Moose', 4, 29.99),
('If I Ran the Zoo', 4, 18.99),
('The Cossacks', 5, 33.99)
('Anna Karenina', 5, 23.99);

INSERT INTO shop.order
(customer_id)
VALUES(1);

INSERT INTO shop.order_book
(order_id, book_id)
VALUES
(1, 2),
(1, 3),
(1, 4),
(1, 5);

-- SELECT * FROM shop.order
-- WHERE shop.order.is_active 

-- SELECT 
-- shop.customer.first_name,
-- shop.customer.last_name,
-- shop.customer.mail,
-- shop.book.title,
-- shop.book.price,
-- shop.author.first_name,
-- shop.author.last_name
-- FROM shop.book
-- JOIN shop.order_book ON shop.book.id = shop.order_book.book_id
-- JOIN shop.author ON shop.book.author_id = shop.author.id
-- JOIN shop.order ON shop.order_book.order_id = shop.order.id
-- JOIN shop.customer ON shop.order.customer_id = shop.customer.id
-- WHERE shop.order.is_active

SELECT
shop."order".id,
SUM(shop.book.price) AS "total"
FROM shop.book
JOIN shop.order_book ON book.id = order_book.book_id
JOIN shop."order" ON order_book.order_id = "order".id
GROUP BY shop."order".id
HAVING shop."order".is_active
ORDER BY total 



