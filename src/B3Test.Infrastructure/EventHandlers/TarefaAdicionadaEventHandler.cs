using B3Test.Domain.Events;
using B3Test.Infrastructure.Messages;
using B3Test.MessageBus.MassTransit.Producers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace B3Test.Infrastructure.EventHandlers
{
    internal class TarefaAdicionadaEventHandler : INotificationHandler<TarefaAdicionadaEvent>
    {
        private readonly ILogger<TarefaAdicionadaEventHandler> _logger;
        private readonly IMessageBusProducer _producer;

        public TarefaAdicionadaEventHandler(ILogger<TarefaAdicionadaEventHandler> logger, IMessageBusProducer producer)
        {
            _logger = logger;
            _producer = producer;
        }

        public async Task Handle(TarefaAdicionadaEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                await _producer.PublishAsync(new NovaTarefaMessage
                {
                    Id = notification.Id,
                    Descricao = notification.Descricao,
                    Status = notification.Status
                });

                _logger.LogInformation($"Tarefa {notification.Id} enviada.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Falha ao publicar evento {nameof(TarefaAdicionadaEvent)} Id: {notification.Id}");
            }
        }
    }
}
