using System;

namespace Domain.Messages.Commands
{
    public class AddProduct : Command
    {
        public string CorrelationId { get; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Id { get; }

        public AddProduct(string id, string correlationId, string name, decimal cost)
        {
            Id = id;
            CorrelationId = correlationId;
            Name = name;
            Cost = cost;
        }
    }
}
