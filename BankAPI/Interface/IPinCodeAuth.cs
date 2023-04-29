using BankAPI.DTOs;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Interface
{
    public interface IPinCodeAuth
    {
        public Task<ActionResult<CardInfo>> PinCodeAuth(CardAuthDTO cardAuth);
    }
}
