using B3Test.MessageBus.MassTransit.Messages;
using B3Test.Shared.Enums;

namespace B3Test.Infrastructure.Messages
{
    public record NovaTarefaMessage : IMessage
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public EStatusTarefa Status { get; set; }
    }
}
