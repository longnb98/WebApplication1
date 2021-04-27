using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public List<User> getUsers() => Users.ToList();

        public List<Book> getBooks() => Books.ToList();

        public void AddUser(User user)
        {
            Users.Add(user);
            this.SaveChanges();
            return;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            this.SaveChanges();
            return;
        }
    }
}
