using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RazorPagesApplication.Models
{
    [BindProperties]
    public class Item
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public long ColumnId { get; private set; }
        public Column Column { get; private set; }

    }
}