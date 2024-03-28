using Caching.Domain;

namespace Caching.Infra.Mapa
{
    public static class TaskSeedData
{
    public static List<TaskItem> Seed()
    {
        List<TaskItem> tasks = new List<TaskItem>();
            DateTime currentUtcTime = DateTime.UtcNow;

            for (int i = 1; i <= 100; i++)
        {
                tasks.Add(new TaskItem(

                    id: i,
                    title: $"Task {i}",
                    description: $"Task Description {i}",
                    deadline: currentUtcTime.AddDays(i),
                    priority: i % 5 + 1,
                    completed: i % 2 == 0
                    ));
        }

        return tasks;
    }
}

}
