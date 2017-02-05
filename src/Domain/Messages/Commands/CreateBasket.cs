namespace Domain.Messages.Commands
{
    public class CreateBasket : Command
    {
        public string Id { get; }
        public string ClientId { get; }

        public CreateBasket(string id, string clientId)
        {
            Id = id;
            ClientId = clientId;
        }
    }
}
