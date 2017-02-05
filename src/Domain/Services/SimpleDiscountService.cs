using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Messages.Events;

namespace Domain.Services
{
    public class SimpleDiscountService : IDiscountService
    {
        // TODO Load the Discount rules from a separate assembly using some sort of rule engine
        private static readonly List<Action<List<Event>>> AvailableDiscounts = new List<Action<List<Event>>>
        {
            ApplyBreadAndButterDiscount,
            Apply3Milk1FreeDiscount
        };

        public void Apply(List<Event> history)
        {
            foreach (var apply in AvailableDiscounts)
                apply(history);
        }

        private static void ApplyBreadAndButterDiscount(List<Event> history)
        {
            var breadCount = history.OfType<ProductAdded>().Count(added => added.Name.Equals("Bread"));
            if (breadCount == 0)
                return;
            var butterCount = history.OfType<ProductAdded>().Count(added => added.Name.Equals("Butter"));
            if (butterCount < 2)
                return;
            var butters = new Stack<ProductAdded>();
            foreach (var result in history.OfType<ProductAdded>().Where(a => a.Name.Equals("Butter")))
                butters.Push(result);
            var breads = new Stack<ProductAdded>();
            foreach (var result in history.OfType<ProductAdded>().Where(a => a.Name.Equals("Bread")))
                breads.Push(result);
            var count = 0;
            while (butters.Count > 0)
            {
                butters.Pop();
                count++;
                if (count != 2) continue;
                var breadToDiscount = breads.Pop();
                history.Add(new DiscountApplied(Guid.NewGuid().ToString(), "BreadAndButterDiscount", breadToDiscount.Id,
                    breadToDiscount.Cost * 50 / 100));
                count = 0;
            }
        }

        private static void Apply3Milk1FreeDiscount(List<Event> history)
        {
            var milkCount = history.OfType<ProductAdded>().Count(added => added.Name.Equals("Milk"));
            if (milkCount < 4) return;
            var milks = new Stack<ProductAdded>();
            foreach (var result in history.OfType<ProductAdded>().Where(a => a.Name.Equals("Milk")))
                milks.Push(result);
            var count = 0;
            while (milks.Count > 0)
            {
                var milkToDiscount = milks.Pop();
                count++;
                if (count < 4) continue;
                history.Add(new DiscountApplied(Guid.NewGuid().ToString(), "MilkDiscount", milkToDiscount.Id, milkToDiscount.Cost));
                count = 0;
            }
        }
    }
}
