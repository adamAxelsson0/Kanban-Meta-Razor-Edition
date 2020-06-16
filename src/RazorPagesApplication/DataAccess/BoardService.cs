using RazorPagesApplication.Context;
using Microsoft.EntityFrameworkCore;  
using RazorPagesApplication.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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
                .Where(column => column.BoardId == boardId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsFromColumnId(long columnId)
        {
            return await _context.Items
                .Where(item => item.ColumnId == columnId)
                .ToListAsync();
        }

        public async Task<Board> GetBoard(long id)
        {
            return await _context.Boards
                .Where(x => x.Id == id)
                .Include(x => x.Columns)
                .ThenInclude(x => x.Items)
                .FirstOrDefaultAsync();
        }

        public async Task<Column> GetColumn(long id)
        {
            return await _context.Columns
                .Where(x => x.Id == id)
                .Include(b => b.Board)
                .Include(x => x.Items)
                .FirstOrDefaultAsync();
        }

        public async Task<Board> CreateBoard(Board board)
        {
            _context.Boards.Add(board);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return board;
            }
            throw new System.Exception("Could not save board to database.");
        }

        public async Task<Column> CreateColumn(Column column)
        {
            _context.Columns.Add(column);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return column;
            }
            throw new System.Exception("Could not save column to database.");
        }

        public async Task<Item> CreateItem(Item item)
        {
            _context.Items.Add(item);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return item;
            }
            throw new System.Exception("Could not save item to database.");
        }

        // FIXME What should delete operations return??
        public async Task<Board> DeleteBoard(Board board)
        {
            _context.Boards.Remove(board);
            var result = await _context.SaveChangesAsync(); 

            if(result > 1) { return board; }
            else 
            {
                return null;
            }
        }
    }
}