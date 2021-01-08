using System;
using System.Collections.Generic;
using BookStoreAPI.Repositories.DbConnection;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Repositories.Queries;
using Dapper;

namespace BookStoreAPI.Repositories.Repositories
{
    public class OrderBookRepository : IOrderBookRepository

    {
        private readonly IDb _db;

        public OrderBookRepository(IDb db)
        {
            _db = db;
        }

        public IEnumerable<OrderBook> GetOrderedBooks()
        {
            var orderedBooks = _db.Connection.Query<OrderBook>(
                OrderBookQueries.GetOrderedBooks);

            return orderedBooks;
        }
    }
}