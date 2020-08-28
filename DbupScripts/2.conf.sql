ALTER TABLE shop.customer
ADD CONSTRAINT unique_email UNIQUE (mail);

ALTER TABLE shop.order
RENAME TO shop_order;

ALTER TABLE shop.author
ADD CONSTRAINT unique_first_last_name UNIQUE (first_name, last_name);

ALTER TABLE shop.book
ADD CONSTRAINT unique_book_title UNIQUE (title);

ALTER TABLE shop.order_book
ALTER COLUMN order_id SET NOT NULL,
ALTER COLUMN book_id SET NOT NULL;

ALTER TABLE shop.book
ALTER COLUMN title SET NOT NULL;

