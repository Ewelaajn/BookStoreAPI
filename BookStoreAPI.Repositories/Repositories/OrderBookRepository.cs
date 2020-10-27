using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Db;
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

        // public OrderBook CreateOrderBook(OrderBook orderBook)
        // {
        //     var insertedId = _db.Connection.Query<int>(OrderBookQueries.CreateOrderBook);
        //
        //     var newOrderBook = 
        //     throw new NotImplementedException();
        // }
        public OrderBook CreateOrderBook(OrderBook orderBook)
        {
            throw new NotImplementedException();
        }
    }
}
