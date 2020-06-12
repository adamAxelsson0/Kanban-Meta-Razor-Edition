using RazorPagesApplication.Context;
using Microsoft.EntityFrameworkCore;  
using RazorPagesApplication.Models;
using System.Threading.Tasks;

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
        
        public async Task<IEnumerable<Column>> GetColumnsFromBoardId(long boardId)
        {
            return await _context.Columns
                .Where(column => column.boardId == boardId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsFromColumnId(long columnId)
        {
            return await _context.Items
                .Where(item => item.columnId == columnId)
                .ToListAsync();
        }

        public async Task<Board> GetBoard(long id)
        {
            return await _context.Boards
                .Include(x => x.Columns)
                .ThenInclude(x => x.Items)
                .FirstOrDefaultAsync();
        }

        public async Task<Column> GetColumn(long id)
        {
            return await _context.Columns
                .Include(x => x.Items)
                .FirstOrDefaultAsync();
        }

        public async Task<Board> CreateBoard(Board board)
        {
            _context.Boards.Add(board);
            var result = await _context.SaveCangesAsync();
            if(result > 0)
            {
                return board;
            }
            throw new System.Exception("Could not save board to database.");
        }

        public async Task<Column> CreateColumn(Column column)
        {
            _context.Columns.Add(column);
            var result = await _context.SaveCangesAsync();
            if(result > 0)
            {
                return column;
            }
            throw new System.Exception("Could not save column to database.");
        }

        public async Task<Item> CreateItem(Item item)
        {
            _context.Items.Add(item);
            var result = await _context.SaveCangesAsync();
            if(result > 0)
            {
                return item;
            }
            throw new System.Exception("Could not save item to database.");
        }
    }
}