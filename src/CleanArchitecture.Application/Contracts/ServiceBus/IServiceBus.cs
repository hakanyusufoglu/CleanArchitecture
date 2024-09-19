using CleanArchitecture.Domain.Events;

namespace CleanArchitecture.Application.Contracts.ServiceBus
{
    //Masstransit projenin yaşam döngüsü boyunca hiç değişme ihtimali yoksa application katmanında direkt olarak kullanılabilir. Ancak şuan bu durum söz konusu değil.
    public interface IServiceBus
    {
        // T = Event veya message olabilir. Event geçmiş olayı temsil eder. Message ise gelecekte yapılacak bir işlemi temsil eder. Direkt queue'ya mesaj göndermek için kullanılır.
        Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IMessage, IEvent;

        //Direkt Exchange'e mesaj göndermek için kullanılır. Exchange: Mesajları alıp ilgili kuyruklara yönlendiren yapıdır.
        Task SendAsync<T>(T message, string queueName, CancellationToken cancellationToken = default) where T : IMessage, IEvent;
    }
}
