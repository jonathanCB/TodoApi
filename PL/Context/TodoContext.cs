using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace PL.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        
    }
}
