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

        public Board()
        {

        }

        public Board(string title)
        {
            this.Title = title;
            this.Columns = new List<Column>();
        }
        //TODO Save to database.
        public void AddColumn(Column column)
        {
            this.Columns.Add(column);
        }

        public void ChangeTitle(string title)
        {
            this.Title = title;
        }
    }
}