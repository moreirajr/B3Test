using B3Test.MessageBus.MassTransit.Messages;
using MassTransit;

namespace B3Test.MessageBus.MassTransit.Producers
{
    public class MassTransitProducer : IMessageBusProducer
    {
        private readonly IBusControl _busControl;

        public MassTransitProducer(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public async Task PublishAsync<T>(T message) where T : IMessage
        {
            await _busControl.Publish(message);
        }
    }
}
