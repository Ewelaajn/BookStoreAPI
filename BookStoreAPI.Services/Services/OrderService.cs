using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IBookRepository bookRepository,
            IAuthorRepository authorRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }
        public OrderDto OrderBook(string title, string mail)
        {
            var order = _orderRepository.CreateOrder(title, mail);
            var book = _bookRepository.GetBookByTitle(title);
            var author = _authorRepository.GetAuthorById(book.AuthorId);

            return new OrderDto
            {
                IsActive = order.IsActive,
                OrderTime = order.OrderTime,
                Book = new OrderedBookDto
                {
                    Title = title,
                    AuthorDto = new AuthorDto
                    {
                        FirstName = author.FirstName,
                        LastName = author.LastName
                    }
                },
                Mail = mail
            };
        }
    }
}
