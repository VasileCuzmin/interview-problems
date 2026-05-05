namespace CovarianceAndContravariance.Contravariance;

public class RegistrationService
{
    // 1. Create our broad, generic logger
    IEventHandler<Event> broadLogger = new GenericEventLogger();

    public void RegisterUser()
    {
        // 2. CONTRAVARIANCE: We assign the broad handler to a variable 
        // expecting a highly specific handler.
        IEventHandler<UserCreatedEvent> specificHandler = broadLogger;

        // 3. We use it safely!
        var newEvent = new UserCreatedEvent { Username = "dave_smith" };
        specificHandler.Handle(newEvent);

        // 3. THE CRASH
        // The specificHandler expects this method to hand back a UserCreatedEvent (with a Username).
        // But the underlying genericHandler(the handler that is passed at runtime - the instance) only hands back a basic Event.
        UserCreatedEvent @event = specificHandler.GetEvent();
    }
}
//
// Why does this make sense?
//     Think of it like a mailroom.
//
//     IEventHandler<UserCreatedEvent> means "I need someone who knows what to do with a User Created letter."
//
// You hand them GenericEventLogger, which is a person who says "I know what to do with literally ANY letter."