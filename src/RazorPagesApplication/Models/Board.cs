using Microsoft.AspNetCore.Mvc;

namespace RazorPagesApplication.Models
{
    [BindProperties]
    public class Board
    {
        public long Id { get; private set; }
    }
}