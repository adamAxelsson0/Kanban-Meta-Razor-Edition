using Microsoft.AspNetCore.Mvc;

namespace RazorPagesApplication.Models
{
    [BindProperties]
    public class ItemDetail
    {
        public long Id { get; private set; }
        public long ItemId { get; private set; }
        public Item Item { get; private set; }
        public string Description { get; private set; }
    }
}