using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesApplication.Models;
using RazorPagesApplication.DataAccess;

namespace RazorPagesApplication.Pages.BoardPages
{
    public class ViewBoardModel : PageModel
    {
        private readonly ILogger<ViewBoardModel> _logger;
        private readonly BoardService _service;
        public Board Board { get; set; }

        public ViewBoardModel(ILogger<ViewBoardModel> logger, BoardService service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task OnGet(int id)
        {
            Board = await _service.GetBoard(id);
        }
        public async Task<IActionResult> OnPostCreateColumn(long boardId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var columnTitle = Request.Form["create-column-title"];

            var board = await _service.GetBoard(boardId);
            Column column = new Column(columnTitle, board);
            column = await _service.CreateColumn(column);

            return RedirectToPage("/BoardPages/ViewBoard", new
            {
                id = column.Board.Id
            });
        }
        public async Task<IActionResult> OnPostCreateItem(long columnId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var itemTitle = Request.Form["create-item-title"];
            var description = Request.Form["create-item-description"];

            var column = await _service.GetColumn(columnId);
            Item item = new Item(itemTitle, description, column);
            item = await _service.CreateItem(item);

            return RedirectToPage("/BoardPages/ViewBoard", new
            {
                id = item.Column.Board.Id
            });
        }
    }
}
