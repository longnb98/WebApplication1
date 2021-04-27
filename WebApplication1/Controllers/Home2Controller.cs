using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home2Controller : ControllerBase
    {
        private readonly ILogger<Home2Controller> _logger;
        private readonly DatabaseContext _database;

        public Home2Controller(ILogger<Home2Controller> logger, DatabaseContext context)
        {
            _logger = logger;
            _database = context;
        }
        [HttpGet]
        [Route("user")]
        public List<User> GetAllUsers() => _database.getUsers();

        [HttpGet]
        [Route("book")]
        public List<Book> GetAllBooks() => _database.getBooks();

        [HttpPost]
        [Route("user")]
        [AllowAnonymous]
        public IActionResult AddUser([FromBody] User user)
        {
            _logger.LogInformation("Add User for UserId: {UserId}", user.UserId);
            _database.AddUser(user);
            return Ok(user);
        }

        [HttpPost]
        [Route("book")]
        [AllowAnonymous]
        public IActionResult AddBook([FromBody] Book book)
        {
            _logger.LogInformation("Add Book for BookId: {BookId}", book.BookId);
            _database.AddBook(book);
            return Ok(book);
        }

    }
}