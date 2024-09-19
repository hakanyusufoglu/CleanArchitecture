namespace CleanArchitecture.Domain.Events
{
    //Best Practise: Eventlar veya messagelar için bir class oluşturulursa bu class'ın propertyleri değiştirilebilir olur. Bu yüzden eventlar ve messagelar için class yerine record kullanılmalıdır.

    //Marker interface kullanılmasının sebebi: IEvent interface'i implemente eden class'lar bir event veya message olabilir. Bu sayede event ve message'ları bir arada tutabiliriz.
    public record ProductAddedEvent(int id, string Name, decimal Price) : IEvent;
}
