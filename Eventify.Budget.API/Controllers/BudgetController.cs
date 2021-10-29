using Eventify.Budget.DomainLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventify.Budget.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : Controller
    {
        private readonly IBudgetRepository _repo;

        public BudgetController(IBudgetRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("/api/Budget/EventId")]
        public async Task<Eventify.Budget.DomainLogic.Budget> GetByEventId(Guid id)
        {
            return await _repo.GetBudgetByEventId(id);
        }

        [HttpGet("/api/Budget/HasBudgetBeenCreated")]
        public async Task<ActionResult> HasBudgetBeenCreated(Guid id)
        {
            if (await _repo.HasBudgetBeenCreated(id))
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete("/api/Budget/Item")]
        public async Task<ActionResult> DeleteItemFromBudget(Guid itemId)
        {
            await _repo.DeleteItemFromBudget(itemId);
            return Ok();
        }

        [HttpGet("/api/Budget/Items")]
        public async Task<List<Item>> GetItemsFromBudgetId(Guid budgetId)
        {
            return await _repo.GetItemsFromBudgetId(budgetId);
        }

        [HttpPost("/api/Budget")]
        public async Task<ActionResult> AddBudget(Guid id, double amount)
        {
            await _repo.AddBudget(id, amount);
            return Ok();
        }

        [HttpPost("/api/Budget/Item")]
        public async Task<ActionResult> AddItem(Guid budgetId, string name, double cost)
        {
            await _repo.AddItemToBudget(budgetId, name, cost);
            return Ok();
        }
    }
}
