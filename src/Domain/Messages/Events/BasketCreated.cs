namespace Domain.Messages.Events
{
    public class BasketCreated : Event
    {
        public string Id { get; }
        public string ClientId { get; }

        public BasketCreated(string id, string clientId)
        {
            Id = id;
            ClientId = clientId;
        }
    }
}
