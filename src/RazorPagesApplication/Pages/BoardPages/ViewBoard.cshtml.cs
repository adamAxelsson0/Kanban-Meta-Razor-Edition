using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesApplication.Models;

namespace RazorPagesApplication.Pages.BoardPages
{
    public class ViewBoardModel : PageModel
    {
        private readonly ILogger<ViewBoardModel> _logger;
        public Column Column { get; set; }
        public Board Board { get; set; }
        public Item Item { get; set; }

        public ViewBoardModel(ILogger<ViewBoardModel> logger)
        {
            _logger = logger;
        }
        public void OnGet(int id)
        {
            //TODO GET BOARD, placeholder for now
            CreateBoard(id);

        }
        public IActionResult OnPostCreateColumn(long boardId)
        {
            var columnTitle = Request.Form["create-column-title"];

            //TODO CRUD OPERATION
            CreateBoard(boardId);
            Column = new Column(1, columnTitle, Board);

            return RedirectToPage("/BoardPages/ViewBoard", new { id = Board.Id });
        }
        public IActionResult OnPostCreateItem(long columnId)
        {
            var itemTitle = Request.Form["create-item"];

            //TODO CRUD OPERATION
            CreateBoard(1);
            Column = new Column(columnId, "PlaceHolder", Board);
            Item = new Item(1, itemTitle, "description", Column);

            return RedirectToPage("/BoardPages/ViewBoard", new { id = Board.Id });
        }
        public void CreateBoard(long id)
        {
            Board = new Board("Placeholder title");
        }
    }
}
