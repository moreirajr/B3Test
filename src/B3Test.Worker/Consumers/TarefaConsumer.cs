using B3Test.Infrastructure.Messages;
using B3Test.MessageBus.MassTransit.Consumers;
using MassTransit;

namespace B3Test.Worker.Consumers
{
    public class TarefaConsumer : IMessageBusConsumer<NovaTarefaMessage>
    {
        private readonly ILogger<TarefaConsumer> _logger;

        public TarefaConsumer(ILogger<TarefaConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<NovaTarefaMessage> context)
        {
            await DoSomethingWithMessageAsync(context.Message);
        }

        private async Task DoSomethingWithMessageAsync(NovaTarefaMessage message)
        {
            _logger.LogInformation($"Message consumed - [Id: {message.Id}]");
            await Task.Delay(100);
        }
    }
}
