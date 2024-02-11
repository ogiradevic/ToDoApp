using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities;

namespace ToDoApp.DbContext
{
    public class ToDoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)

        {

        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
