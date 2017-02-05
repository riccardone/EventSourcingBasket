namespace Domain.Messages.Events
{
    public interface Event : Message
    {
        string Id { get; }
        string CorrelationId { get; }
        string CausationId { get; }
    }
}
