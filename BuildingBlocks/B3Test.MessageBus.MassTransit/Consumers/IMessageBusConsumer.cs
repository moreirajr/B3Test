using B3Test.MessageBus.MassTransit.Messages;
using MassTransit;

namespace B3Test.MessageBus.MassTransit.Consumers
{
    public interface IMessageBusConsumer<in TMessage> : IConsumer<TMessage>
       where TMessage : class, IMessage
    {
        //Task ConsumeAsync(ConsumeContext<TMessage> consumerContext, CancellationToken cancellationToken);
    }
}
