using RazorPagesApplication.Context;
using Microsoft.EntityFrameworkCore;  
using RazorPagesApplication.Models;

namespace RazorPagesApplication.DataAccess
{
    public class BoardService
    {
        private readonly KanbanContext _context; 
        public BoardService(KanbanContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Board>> GetBoards()
        {
            return await _context.Boards.ToListAsync();
        }

        public async Task<Board> GetBoard(long id)
        {
            return await _context.Boards
                .Include(x => x.Columns)
                .ThenInclude(x => x.Items)
                .FirstOrDefaultAsync();
        }
    }
}