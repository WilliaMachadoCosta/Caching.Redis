using Caching.Domain;

namespace Caching.Infra.Mapa
{
    public static class TarefaSeedData
{
    public static List<Tarefa> Seed()
    {
        List<Tarefa> tarefas = new List<Tarefa>();

        for (int i = 1; i <= 10000; i++)
        {
                tarefas.Add(new Tarefa(

                    id: i,
                    titulo: $"Tarefa {i}",
                    descricao: $"Descrição da tarefa {i}",
                    dataLimite: DateTime.Now.AddDays(i),
                    prioridade: i % 5 + 1,
                    concluida: i % 2 == 0
                    ));

         
           
        }

        return tarefas;
    }
}

}
