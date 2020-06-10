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

        public Board(long _id, string _title){
            this.Id = _id;
            this.Title = _title;
        }
    }
}