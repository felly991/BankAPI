using BankAPI.Data;
using BankAPI.DTOs;
using BankAPI.Interface;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankAPI.Service
{
    public class PinCodeAuthService : IPinCodeAuth
    {
        private readonly DataContext _context;

        public PinCodeAuthService(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<CardInfo>>? PinCodeAuth(CardAuthDTO cardAuth) 
        {
            var card = await _context.cardInfos.Include(c => c.PinCode)
                                               .Include(u => u.User)
                                               .Include(b => b.Balance)
                                               .FirstOrDefaultAsync(x => x.CardNumber == cardAuth.cardNumber);
            if (card == null || card.PinCode.Code != cardAuth.code)
            {
                return null;
            }
            else
            {
                return card;
            }
        }
    }
}
