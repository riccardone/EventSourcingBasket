namespace Domain.Messages.Events
{
    public class ProductAdded : Event
    {
        public string Id { get; }
        public string Name { get; }
        public decimal Cost { get; }

        public ProductAdded(string id, string name, decimal cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}
