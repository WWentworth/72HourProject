using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _72HourProject.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("DefaultConnection") { }


        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}