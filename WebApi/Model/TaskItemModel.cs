namespace WebApi.Model
{
    public class TaskItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public bool Completed { get; set; }
    }
}
