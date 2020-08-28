DROP SCHEMA IF EXISTS shop CASCADE;
CREATE SCHEMA shop;

CREATE TABLE shop.customer 
(
	id SERIAL PRIMARY KEY,
	first_name TEXT,
	last_name TEXT,
	mail TEXT,
	phone_number TEXT,
	city TEXT
);

CREATE TABLE shop.author
(
	id SERIAL PRIMARY KEY,
	first_name TEXT,
	last_name TEXT
);

CREATE TABLE shop.book
(
	id SERIAL PRIMARY KEY,
	title TEXT,
	author_id INT REFERENCES shop.author(id),
	price DECIMAL(4,2)
);

CREATE TABLE shop.order
(
	id SERIAL PRIMARY KEY,
	is_active BOOL DEFAULT TRUE,
	order_time TIMESTAMP DEFAULT NOW(),
	customer_id INTEGER REFERENCES shop.customer(id)
);

CREATE TABLE shop.order_book
(
	order_id INTEGER REFERENCES shop.order(id),
	book_id INTEGER REFERENCES shop.book(id)
);
