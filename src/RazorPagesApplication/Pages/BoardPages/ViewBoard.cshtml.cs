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
        public Board board { get; set; }

        public ViewBoardModel(ILogger<ViewBoardModel> logger)
        {
            _logger = logger;
        }
        public void OnGet(int id)
        {
            //TODO GET BOARD, placeholder for now
            board = new Board(id, "Placeholder title");
        }
    }
}
