using System.Collections.Generic;
using System.Linq;
using Domain.Messages.Events;

namespace Tests
{
    public class TestModel
    {
        private readonly List<Event> _cache = new List<Event>();
        public void Save(List<Event> events)
        {
            _cache.AddRange(events);
        }
        public decimal GetBasketTotal()
        {
            var total = _cache.OfType<ProductAdded>().Sum(prod => prod.Cost);
            return _cache.OfType<DiscountApplied>()
                .Aggregate(total, (current, offer) => current - offer.DiscountAmount);
        }
    }
}
