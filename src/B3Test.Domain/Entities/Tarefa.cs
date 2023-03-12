using B3Test.Domain.SeedWork;
using B3Test.Shared.Enums;

namespace B3Test.Domain.Entities
{
    public class Tarefa : AEntity<Guid>
    {
        public string? Descricao { get; private set; }
        public EStatusTarefa Status { get; private set; }

        public Tarefa() { }
        private Tarefa(string descricao, EStatusTarefa status)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Status = status;
        }

        public static Tarefa Create(string descricao, EStatusTarefa status)
            => new Tarefa(descricao, status);
    }
}
