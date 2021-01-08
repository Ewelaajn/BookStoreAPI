using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Repositories.DbConnection;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Repositories.Queries;
using Dapper;

namespace BookStoreAPI.Repositories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDb _db;

        public OrderRepository(IDb db)
        {
            _db = db;
        }

        public Order CreateOrder(string title, string mail)
        {
            var customer = _db.Connection.QueryFirstOrDefault<Customer>(
                CustomerQueries.GetCustomerByMail, new {mail});
            var book = _db.Connection.QueryFirstOrDefault<Book>(
                BookQueries.GetBookByTitle, new {title});
            var order = _db.Connection.QueryFirst<Order>(
                OrderQueries.CreateOrder, new {CustomerId = customer.Id});
            _db.Connection.Execute(
                OrderBookQueries.CreateOrderBook, new {OrderId = order.Id, BookId = book.Id});

            return order;
        }

        public IEnumerable<Order> GetOrdersByIds(List<int> ids)
        {
            var orders = _db.Connection.Query<Order>(
                OrderQueries.GetOrdersByIds, new {ids});

            return orders.ToList();
        }
    }
}