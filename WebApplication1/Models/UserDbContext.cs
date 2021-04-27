using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) // constructor
        {
            LoadDefaultUsers();
        }
        public List<User> GetUsers() => Users.Local.ToList<User>();
        private void LoadDefaultUsers()
        {
            Users.Add(new User { UserId = 166, Name = "An", Gender = "Nam", DOB = Convert.ToDateTime("09-28-1998")});
            Users.Add(new User { UserId = 167, Name = "Binh", Gender = "Nam", DOB = Convert.ToDateTime("09-27-1997")});
        }
        
    }
}
