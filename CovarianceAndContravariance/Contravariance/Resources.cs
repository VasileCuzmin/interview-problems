namespace CovarianceAndContravariance.Contravariance;

// The broad, generic concept
public class Event
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

// The specific concept
public class UserCreatedEvent : Event
{
    public string Username { get; set; }
}

// The 'in' keyword guarantees T is only ever used as a parameter.
public interface IEventHandler<in T>
{
    void Handle(T domainEvent);
    T GetEvent(); //compile error;
}

// This handler can process absolutely ANY Event
public class GenericEventLogger : IEventHandler<Event>
{
    public void Handle(Event domainEvent)
    {
        Console.WriteLine($"[LOG] An event occurred at {domainEvent.Timestamp}");
    }

    public Event GetEvent()
    {
        return new Event();
    }
}