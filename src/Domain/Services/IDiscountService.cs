using System.Collections.Generic;
using Domain.Messages.Events;

namespace Domain.Services
{
    public interface IDiscountService
    {
        void Apply(List<Event> history);
    }
}
