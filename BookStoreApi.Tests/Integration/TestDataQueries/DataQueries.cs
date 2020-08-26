using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApi.Tests.Integration.TestDataQueries
{
    public class DataQueries
    {
        public const string InsertIntoShopAuthor = @"INSERT INTO shop.author 
                                                        (first_name, last_name)
                                                    VALUES
                                                        ('William', 'Shakespeare'),
                                                        ('Aghata', 'Christie'),
                                                        ('Edwin', 'Abbott'),
                                                        ('Barbara', 'Cartland'),
                                                        ('Stephen', 'King');";

        public const string InsertIntoShopBook = @"
                                                 INSERT INTO shop.book
                                                    (title, author_id, price)
                                                 VALUES
                                                    ('Romeo and Juliet', 1, 30.00),
                                                    ('Murder on the Orient Express', 2, 25.00),
                                                    ('Flatland', 3, 35.00),
                                                    ('The Cossacks', 4, 28.00),
                                                    ('IT', 5, 32.00);";

        public const string InsertIntoShopCustomer = @"
                                                     INSERT INTO shop.customer
                                                        (first_name, last_name, mail, phone_number, city)
                                                     VALUES
                                                        ('Ewelina', 'Pawlowska', 'e.pawlowska@gmail.com', 654123098, 'Krakow'),
                                                        ('Sylwia', 'Maslak', 's.maslak@gmail.com', 546234756, 'Wroclaw'),
                                                        ('Mariusz', 'Gorac', 'm.gorac@gmail.com', 576075473, 'Warszawa');";

        public const string InsertIntoShopOrder = "";
    }
}
