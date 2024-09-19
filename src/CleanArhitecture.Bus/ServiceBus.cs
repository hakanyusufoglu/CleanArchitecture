using CleanArchitecture.Application.Contracts.ServiceBus;
using CleanArchitecture.Domain.Events;
using MassTransit;

namespace CleanArhitecture.Bus
{
    public class ServiceBus(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider) : IServiceBus
    {
        public async Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IMessage, IEvent
        {
            await publishEndpoint.Publish(@event, cancellationToken);
        }

        public async Task SendAsync<T>(T message, string queueName, CancellationToken cancellationToken = default) where T : IMessage, IEvent
        {
            //Önce kuyruk oluşturulmalı. Kuyruk oluşturulduktan sonra mesaj gönderilebilir.
            var endpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"));

            await endpoint.Send(message, cancellationToken);
        }
    }
}
