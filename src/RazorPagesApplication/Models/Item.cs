using Microsoft.AspNetCore.Mvc;

namespace RazorPagesApplication.Models
{
    [BindProperties]
    public class Item
    {
        public long Id { get; private set; }
        public long ColumnId { get; private set; }
        public Column Column { get; private set; }

    }
}