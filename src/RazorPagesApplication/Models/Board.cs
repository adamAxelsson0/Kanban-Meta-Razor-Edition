using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace RazorPagesApplication.Models
{
    [BindProperties]
    public class Board
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public List<Column> Columns { get; private set; }
    }
}