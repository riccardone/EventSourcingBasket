namespace Domain.Messages.Events
{
    public interface Event : Message
    {
        string Id { get; }
    }
}
