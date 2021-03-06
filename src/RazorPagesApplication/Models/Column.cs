using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace RazorPagesApplication.Models
{
    [BindProperties]
    public class Column
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public long BoardId { get; private set; }
        public Board Board { get; private set; }
        public List<Item> Items { get; private set; }

        public Column()
        {

        }

        public Column(string title, Board board)
        {
            this.Title = title;
            this.BoardId = board.Id;
            this.Board = board;
            this.Items = new List<Item>();
        }
    }
}