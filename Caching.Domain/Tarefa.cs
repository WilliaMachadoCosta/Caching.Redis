namespace Caching.Domain
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLimite { get; set; }
        public int Prioridade { get; set; }
        public bool Concluida { get; set; }

        public Tarefa(int id, string titulo, string descricao, DateTime dataLimite, int prioridade, bool concluida)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataLimite = dataLimite;
            Prioridade = prioridade;
            Concluida = concluida;
        }

        public override string ToString()
        {
            return $"Tarefa: {Titulo}\nDescrição: {Descricao}\nData Limite: {DataLimite}\nPrioridade: {Prioridade}\nConcluída: {(Concluida ? "Sim" : "Não")}";
        }

        public void Concluir()
        {
            Concluida = true;
        }

        public void AlterarPrioridade(int novaPrioridade)
        {
            Prioridade = novaPrioridade;
        }

        public void EditarTitulo(string novoTitulo)
        {
            Titulo = novoTitulo;
        }

        public void EditarDescricao(string novaDescricao)
        {
            Descricao = novaDescricao;
        }

        public void EditarDataLimite(DateTime novaDataLimite)
        {
            DataLimite = novaDataLimite;
        }
    }
}
