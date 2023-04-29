using BankAPI.DTOs;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Interface
{
    public interface IBalanceOperations
    {
        public Task<ActionResult<Balance>?>? ChangeMoney(int amount, CardAuthDTO cardAuth);
        public Task<ActionResult<Balance>?>? CheckBalance(CardAuthDTO cardAuth);
    }
}
