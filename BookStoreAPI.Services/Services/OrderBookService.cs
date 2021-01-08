using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services.Services
{
    public class OrderBookService : IOrderBookService
    {
        private readonly IOrderBookRepository _orderBookRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderBookService(
            IOrderBookRepository orderBookRepository,
            IOrderRepository orderRepository,
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            ICustomerRepository customerRepository)
        {
            _orderBookRepository = orderBookRepository;
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _customerRepository = customerRepository;
        }
        public IEnumerable<OrderDto> GetOrderedBooks()
        {
            var booksOrders = _orderBookRepository.GetOrderedBooks().ToList();
            
            var orderIds = booksOrders.Select(order => order.OrderId).ToList();
            var bookIds = booksOrders.Select(order => order.BookId).ToList();
            
            var orders = _orderRepository.GetOrdersByIds(orderIds).ToList();
            var books = _bookRepository.GetBooksByIds(bookIds).ToList();
            
            var authorIds = books.Select(book => book.AuthorId).ToList();
            var authors = _authorRepository.GetAuthorsByIds(authorIds).ToList();

            var orderedBooks = booksOrders
                .Select(order => new OrderDto
                {
                    IsActive = orders.Single(o => o.Id == order.OrderId).IsActive,
                    OrderTime = orders.Single(o => o.Id == order.OrderId).OrderTime,

                    Book = new OrderedBookDto
                    {
                        Title = books.Single(b => b.Id == order.BookId).Title,
                        AuthorDto = new AuthorDto
                        {
                            FirstName = authors
                                .Single(a => a.Id == books
                                    .Single(b => b.AuthorId == a.Id).AuthorId).FirstName,
                            LastName = authors
                                .Single(a => a.Id == books
                                    .Single(b => b.AuthorId == a.Id).AuthorId).LastName
                        }
                    },

                    Mail = _customerRepository
                        .GetCustomerById(orders
                            .Single(ord => ord.Id == order.OrderId).CustomerId).Mail
                });

            return orderedBooks.ToList();
        }
    }
}
