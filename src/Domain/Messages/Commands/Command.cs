namespace Domain.Messages.Commands
{
    public interface Command : Message
    {
        string Id { get; }
    }
}
