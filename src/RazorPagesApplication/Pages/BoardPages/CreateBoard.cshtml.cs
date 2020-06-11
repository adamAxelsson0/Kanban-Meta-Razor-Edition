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
    public class CreateBoardModel : PageModel
    {
        private readonly ILogger<CreateBoardModel> _logger;

        private Board board { get; set; }

        public CreateBoardModel(ILogger<CreateBoardModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Send this item
            var boardTitle = Request.Form["create-board-title"];
            // TODO: Save to database
            //Board board = await 
            //return RedirectToPage($"/Board/{board.Id}");
            board = new Board(1, boardTitle);

            return RedirectToPage("/BoardPages/ViewBoard", new {id = board.Id});
        }
    }
}
