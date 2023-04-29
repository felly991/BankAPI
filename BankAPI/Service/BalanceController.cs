using BankAPI.Data;
using BankAPI.DTOs;
using BankAPI.Interface;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Service
{
    public class BalanceController : IBalanceOperations
    {
        private readonly IPinCodeAuth _pinCodeAuth;
        private readonly DataContext _context;

        public BalanceController(IPinCodeAuth pinCodeAuth, DataContext context)
        {
           _pinCodeAuth = pinCodeAuth;
            _context = context;
        }
        public async Task<ActionResult<Balance>?>? CheckBalance(CardAuthDTO cardAuth)
        {
            var card = await _context.cardInfos
                    .Include(b => b.Balance)
                    .FirstOrDefaultAsync(x => x.CardNumber == cardAuth.cardNumber);
            if (_pinCodeAuth.PinCodeAuth(cardAuth) != null && card != null)
            {
                return card.Balance;
            }
            else
            {
                return null;
            }
        }

        public async Task<ActionResult<Balance>?>? ChangeMoney(int amount, CardAuthDTO cardAuth)
        {
            var card = await _context.cardInfos
                    .Include(b => b.Balance)
                    .Include(o => o.OperationsCount)
                    .FirstOrDefaultAsync(x => x.CardNumber == cardAuth.cardNumber);
            if (_pinCodeAuth.PinCodeAuth(cardAuth) != null && card != null)
            {
                if (card.OperationsCount.Count < 1)
                {
                    card.OperationsCount.Count += 1;
                    var balance = new Balance
                    {
                        balance = card.Balance.balance + amount
                    };
                    if (balance.balance < 0)
                    {
                        return card.Balance;
                    }
                    card.Balance = balance;
                    await _context.SaveChangesAsync();
                    return card.Balance;
                }
                return null;
                
            }
            else
            {
                return null;
            }

        }

    }
}
