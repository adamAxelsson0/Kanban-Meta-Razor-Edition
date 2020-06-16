using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesApplication.DataAccess;
using RazorPagesApplication.Models;

namespace RazorPagesApplication
{
    public class EditBoardModel : PageModel
    {
        private readonly ILogger _logger;
        private readonly BoardService _service;

        public Board ActiveBoard { get; set; }
        public List<string> Messages { get; set; }

        public EditBoardModel(ILogger<EditBoardModel> logger, BoardService service)
        {
           _logger = logger;
           _service = service; 
           Messages = new List<string>();
        }
        public async Task OnGet(long boardId)
        {
            ActiveBoard = await _service.GetBoard(boardId);
        }

        public async Task<IActionResult> OnPostDeleteBoard(long boardId)
        {
            try 
            {
                var board = await _service.GetBoard(boardId);
                await _service.DeleteBoard(board);
                return RedirectToPage("/Index");
            }
            catch(Exception ex)
            {
                Messages.Add(ex.Message);
                // Redirect to appropriate page
                // Send messages back to page
                return Page();
            }
        }

        public async Task<IActionResult> OnPostEditBoard(int boardId)
        {
            // Create new Board form form input.
            var board = await _service.GetBoard(boardId);
            var newTitle = Request.Form["edit-board-title"];
            board.ChangeTitle(newTitle);
            
            try
            {
                await _service.EditBoard(board);
                return RedirectToPage("viewboard", new { board.Id });
            }
            catch(Exception ex)
            {
                Messages.Add(ex.Message);
                return null;
            }

        }
    }
}
