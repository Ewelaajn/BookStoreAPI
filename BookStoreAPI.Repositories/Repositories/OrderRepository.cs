using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Db;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Models;

namespace BookStoreAPI.Repositories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDb _db;

        public OrderRepository(IDb db)
        {
            _db = db;
        }

        public Order CreateOrder(Order order)
        {

            throw new NotImplementedException();
        }
    }
}
