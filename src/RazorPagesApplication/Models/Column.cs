using Microsoft.AspNetCore.Mvc;

namespace RazorPagesApplication.Models
{
    [BindProperties]
    public class Column
    {
        public long Id { get; private set; }
        public long BoardId { get; private set; }
        public Board Board { get; private set; }
    }
}