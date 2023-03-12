using B3Test.MessageBus.MassTransit.Messages;

namespace B3Test.MessageBus.MassTransit.Producers
{
    public interface IMessageBusProducer
    {
        Task PublishAsync<T>(T message) where T : IMessage;
    }
}
