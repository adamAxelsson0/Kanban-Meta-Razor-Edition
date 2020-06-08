namespace RazorPagesApplication.Models
{
    public class TaskDetails
    {
        public long Id {get; private set;}
        public long TaskId {get; private set;}
        public Task Task {get; private set;}
        public string Description {get; private set;}
    }
}