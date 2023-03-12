using B3Test.Domain.Entities;
using B3Test.Shared.Enums;
using MediatR;

namespace B3Test.Domain.Events
{
    public class TarefaAdicionadaEvent : INotification
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public EStatusTarefa Status { get; set; }

        public TarefaAdicionadaEvent() { }

        public TarefaAdicionadaEvent(Tarefa tarefa)
        {
            Id = tarefa.Id;
            Descricao = tarefa.Descricao;
            Status = tarefa.Status;
        }
    }
}
