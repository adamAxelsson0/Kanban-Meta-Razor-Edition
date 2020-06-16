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

        public Item()
        {

        }

        public Item(string title, string description, Column column)
        {
            this.Title = title;
            this.ColumnId = column.Id;
            this.Column = column;
            this.Description = description;
        }

    }
}