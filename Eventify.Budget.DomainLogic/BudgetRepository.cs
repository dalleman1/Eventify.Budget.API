using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventify.Budget.DomainLogic
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly BudgetContext _context;

        public BudgetRepository(BudgetContext context)
        {
            _context = context;
        }
        public async Task AddBudget(Guid eventId, double amount)
        {
            var budget = new Budget
            {
                Id = Guid.NewGuid(),
                EventId = eventId,
                BudgetAmount = amount,
                Items = new List<Item>()
            };

            await _context.AddAsync<Budget>(budget);
            await _context.SaveChangesAsync();
        }

        public async Task AddItemToBudget(Guid budgetId, string name, double cost)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                BudgetId = budgetId,
                Cost = cost,
                Name = name
            };
            _context.items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemFromBudget(Guid itemId)
        {
            var item = await _context.FindAsync<Item>(itemId);
            _context.items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Budget> GetBudgetByEventId(Guid eventId)
        {
            return await Task.Run(() => _context.budgets.Where(x => x.EventId == eventId).FirstOrDefault());
        }

        public async Task<List<Item>> GetItemsFromBudgetId(Guid budgetId)
        {
            return await Task.Run(() => _context.items.Where(x => x.BudgetId == budgetId).ToList());
        }

        public async Task<bool> HasBudgetBeenCreated(Guid eventId)
        {
            var budget = await Task.Run(() => _context.budgets.Where(x => x.EventId == eventId).FirstOrDefault());
            if (budget == null)
            {
                return false;
            }
            else return true;
        }
    }
}
