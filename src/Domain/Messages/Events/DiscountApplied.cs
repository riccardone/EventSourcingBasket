namespace Domain.Messages.Events
{
    public class DiscountApplied : Event
    {
        public string Id { get; }
        public string OfferName { get; }
        public string ProductIdDiscounted { get; }
        public decimal DiscountAmount { get; }

        public DiscountApplied(string id, string offerName, string productIdDiscounted, decimal discountAmount)
        {
            Id = id;
            OfferName = offerName;
            ProductIdDiscounted = productIdDiscounted;
            DiscountAmount = discountAmount;
        }
    }
}
