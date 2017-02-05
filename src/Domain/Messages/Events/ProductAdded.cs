namespace Domain.Messages.Events
{
    public class ProductAdded : Event
    {
        public string Id { get; }
        public string CausationId { get; }
        public string CorrelationId { get; }
        public string Name { get; }
        public decimal Cost { get; }

        public ProductAdded(string id, string causationId, string correlationId, string name, decimal cost)
        {
            Id = id;
            CausationId = causationId;
            CorrelationId = correlationId;
            Name = name;
            Cost = cost;
        }
    }
}
