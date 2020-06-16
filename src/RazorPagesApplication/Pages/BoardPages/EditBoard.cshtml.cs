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
        }
        public async Task OnGet(int id)
        {
            ActiveBoard = await _service.GetBoard((long)id);
        }

        public async Task<IActionResult> OnDeleteBoard(Board board)
        {
            try 
            {
                await _service.DeleteBoard(ActiveBoard);
                return RedirectToPage("viewboard", new { board.Id });
            }
            catch(Exception ex)
            {
                Messages.Add(ex.Message);
                // Redirect to appropriate page
                return null;
            }
        }

        public async Task<IActionResult> OnPutEditBoard(Board board)
        {
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
