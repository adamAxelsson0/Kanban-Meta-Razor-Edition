using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesApplication.Models;
using RazorPagesApplication.DataAccess;

namespace RazorPagesApplication.Pages.ItemPages
{
    public class EditItemModel : PageModel
    {
        private readonly ILogger<EditItemModel> _logger;
        private readonly BoardService _service;

        public Item Item { get; set; }
        public Board Board {get;set;}

        public EditItemModel(ILogger<EditItemModel> logger, BoardService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task OnGet(long id)
        {
            Item = await _service.GetItem(id);
            Board = await _service.GetBoard(Item.Column.Board.Id);

        }
        public async Task<IActionResult> OnPostEditItem(long id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Item = await _service.GetItem(id);
            
            var itemTitle = Request.Form["item-title"];
            var itemDescription = Request.Form["item-description"];
            long itemColumnId = long.Parse(Request.Form["item-column"]);

            Column column = await _service.GetColumn(itemColumnId);

            Item = Item.EditItem(itemTitle, itemDescription, column);

            await _service.EditItem(Item);

            return RedirectToPage("/BoardPages/ViewBoard", new
            {
                id = Item.Column.Board.Id
            });
        }
    }
}
