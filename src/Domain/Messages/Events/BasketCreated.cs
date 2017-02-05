namespace Domain.Messages.Events
{
    public class BasketCreated : Event
    {
        public string Id { get; }
        public string CorrelationId { get; }
        public string CausationId { get; }
        public string ClientId { get; }

        public BasketCreated(string id, string causationId, string correlationId, string clientId)
        {
            Id = id;
            CausationId = causationId;
            CorrelationId = correlationId;
            ClientId = clientId;
        }
    }
}
