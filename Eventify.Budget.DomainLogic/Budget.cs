using System;
using System.Collections.Generic;

namespace Eventify.Budget.DomainLogic
{
    public class Budget
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public double BudgetAmount { get; set; }
        public List<Item> Items { get; set; }
    }
}
