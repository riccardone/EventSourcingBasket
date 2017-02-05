using System;
using System.Collections.Generic;
using Domain.Messages.Commands;
using Domain.Messages.Events;
using Domain.Services;

namespace Domain.Aggregates
{
    public class Basket
    {
        private Basket() { }

        public static List<Event> Create(CreateBasket cmd)
        {
            Ensure.NotNull(cmd, nameof(cmd));
            Ensure.NotNullOrEmpty(cmd.Id, nameof(cmd.Id));
            Ensure.NotNullOrEmpty(cmd.ClientId, nameof(cmd.ClientId));
            return new List<Event> { new BasketCreated(cmd.Id, cmd.Id, cmd.Id, cmd.ClientId) };
        }

        public static List<Event> Buy(List<Event> history, AddProduct cmd)
        {
            Ensure.NotNull(cmd, nameof(cmd));
            Ensure.NotNullOrEmpty(cmd.Name, nameof(cmd.Name));
            Ensure.Nonnegative(cmd.Cost, nameof(cmd.Cost));
            history.Add(new ProductAdded(Guid.NewGuid().ToString(), cmd.Id, cmd.CorrelationId, cmd.Name, cmd.Cost));
            return history;
        }

        public static List<Event> CheckOut(List<Event> history, IDiscountService discountService)
        {
            Ensure.NotNull(discountService, nameof(discountService));
            Ensure.NotNull(history, nameof(history));
            discountService.Apply(history);
            return history;
        }
    }
}
