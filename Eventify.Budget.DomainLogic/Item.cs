using System;

namespace Eventify.Budget.DomainLogic
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public Guid BudgetId { get; set; }
        public Budget budget { get; set; }
    }
}
