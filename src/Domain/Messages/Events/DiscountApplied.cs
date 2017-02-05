namespace Domain.Messages.Events
{
    public class DiscountApplied : Event
    {
        public string Id { get; }
        public string CausationId { get; }
        public string CorrelationId { get; }
        public string OfferName { get; }
        public string ProductIdDiscounted { get; }
        public decimal DiscountAmount { get; }

        public DiscountApplied(string id, string causationId, string correlationId, string offerName, string productIdDiscounted, decimal discountAmount)
        {
            Id = id;
            CausationId = causationId;
            CorrelationId = correlationId;
            OfferName = offerName;
            ProductIdDiscounted = productIdDiscounted;
            DiscountAmount = discountAmount;
        }
    }
}
