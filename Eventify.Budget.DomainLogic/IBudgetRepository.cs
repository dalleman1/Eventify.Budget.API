using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventify.Budget.DomainLogic
{
    public interface IBudgetRepository
    {
        Task<Budget> GetBudgetByEventId(Guid eventId);
        Task<List<Item>> GetItemsFromBudgetId(Guid budgetId);
        Task AddBudget(Guid eventId, double amount);
        Task DeleteItemFromBudget(Guid itemId);
        Task AddItemToBudget(Guid budgetId, string name, double cost);
        Task<bool> HasBudgetBeenCreated(Guid eventId);
    }
}
