
namespace Caching.Domain
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public bool Completed { get; set; }

        public TaskItem(int id, string title, string description, DateTime deadline, int priority, bool completed)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            Priority = priority;
            Completed = completed;
        }

        public override string ToString()
        {
            return $"Task: {Title}\nDescription: {Description}\nDeadline: {Deadline}\nPriority: {Priority}\nCompleted: {(Completed ? "Yes" : "No")}";
        }

        public void Complete()
        {
            Completed = true;
        }

        public void ChangePriority(int newPriority)
        {
            Priority = newPriority;
        }

        public void EditTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void EditDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void EditDeadline(DateTime newDeadline)
        {
            Deadline = newDeadline;
        }
    }
}