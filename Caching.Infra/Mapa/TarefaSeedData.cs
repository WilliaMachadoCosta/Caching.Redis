using Caching.Domain;

namespace Caching.Infra.Mapa
{
    public static class TarefaSeedData
{
    public static List<TaskItem> Seed()
    {
        List<TaskItem> tasks = new List<TaskItem>();

        for (int i = 1; i <= 3000; i++)
        {
                tasks.Add(new TaskItem(

                    id: i,
                    title: $"Task {i}",
                    description: $"Task Description {i}",
                    deadline: DateTime.Now.AddDays(i),
                    priority: i % 5 + 1,
                    completed: i % 2 == 0
                    ));
        }

        return tasks;
    }
}

}
