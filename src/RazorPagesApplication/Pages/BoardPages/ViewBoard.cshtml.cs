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

        public ViewBoardModel(ILogger<ViewBoardModel> logger)
        {
            _logger = logger;
        }
        public void OnGet(int id)
        {
            //TODO GET BOARD, placeholder for now
            CreateBoard(id);

        }
        public IActionResult OnPost(int id)
        {
            var columnTitle = Request.Form["create-column-title"];
            Column = new Column(1, columnTitle);

            CreateBoard(id);
            Board.AddColumn(Column);
            return RedirectToPage("/BoardPages/ViewBoard", new { id = Board.Id });
        }
        public void CreateBoard(long id)
        {
            Board = new Board(id, "Placeholder title");
        }
    }
}
