using Microsoft.EntityFrameworkCore;
using RazorPagesApplication.Models;

namespace RazorPagesApplication.Context
{
    public class KanbanContext: DbContext
    {
        public KanbanContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Column> Columns { get; set; }
    }
}
   