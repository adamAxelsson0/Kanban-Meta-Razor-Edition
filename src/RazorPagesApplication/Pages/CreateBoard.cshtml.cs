using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesApplication.Models;

namespace RazorPagesApplication.Pages
{
    public class CreateBoardModel : PageModel
    {
        private readonly ILogger<CreateBoardModel> _logger;

        public Board Board { get; set; }
        public Column Column { get; set; }
        public Item Item { get; set; }
        public ItemDetails ItemDetails { get; set; }

        public CreateBoardModel(ILogger<CreateBoardModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            var boardTitle = Request.Form["create-board-title"];
            Console.WriteLine(boardTitle);
            // TODO: Save to database
            //RazorPagesApplication.Models.Board board = await 
            //return RedirectToPage($"/Board/{board.Id}");
            return RedirectToPage($"/Index");
        }
    }
}
