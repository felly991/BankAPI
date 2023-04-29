using BankAPI.DTOs;
using BankAPI.Interface;
using BankAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceOperations _balanceOperations;

        public BalanceController(IBalanceOperations balanceOperations)
        {
            _balanceOperations = balanceOperations;
        }

        [HttpGet]
        public async Task<ActionResult<Balance>> CheckBalance([FromQuery]CardAuthDTO cardAuth)
        {
            var balance = await _balanceOperations.CheckBalance(cardAuth);
            if(balance == null)
            {
                return NotFound("Card not found");
            }
            else
            {
                return balance;
            }
        }
        [HttpGet("amount")]
        public async Task<ActionResult<Balance>?>? ChangeMoney([FromQuery]int amount, [FromQuery]CardAuthDTO cardAuth)
        {
            var balance = await _balanceOperations.ChangeMoney(amount, cardAuth);
            if (balance == null)
            {
                return NotFound("Card not found");
            }
            else
            {
                return balance;
            }
        }
    }
}
