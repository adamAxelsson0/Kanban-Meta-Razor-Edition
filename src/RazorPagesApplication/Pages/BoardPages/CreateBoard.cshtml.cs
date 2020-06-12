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
    public class CreateBoardModel : PageModel
    {
        private readonly ILogger<CreateBoardModel> _logger;
        private readonly BoardService _service;

        private Board board { get; set; }

        public CreateBoardModel(ILogger<CreateBoardModel> logger, BoardService service)
        {
            _logger = logger;
            _service = service;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var boardTitle = Request.Form["create-board-title"];

            Board board = new Board(boardTitle);

            board = await _service.CreateBoard(board);

            return RedirectToPage("/BoardPages/ViewBoard", new
            {
                id = board.Id
            });
        }
    }
}
