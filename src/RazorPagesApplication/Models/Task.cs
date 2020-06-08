namespace RazorPagesApplication.Models
{
    public class Task
    {
        public long Id {get; private set;}
        public long ColumnId {get; private set;}
        public Column Column {get; private set;}

    }
}