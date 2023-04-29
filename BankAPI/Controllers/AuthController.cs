using BankAPI.DTOs;
using BankAPI.Interface;
using BankAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IPinCodeAuth _pinCodeAuth;
        public AuthController(IPinCodeAuth pinCodeAuth)
        {
            _pinCodeAuth = pinCodeAuth;
        }
        [HttpGet]
        public async Task<ActionResult<CardInfo>> PinCodeAuth([FromQuery] CardAuthDTO cardAuth)
        {
            var card = await _pinCodeAuth.PinCodeAuth(cardAuth);
            if (card == null)
            {
                return NotFound("Card not found");
            }
            else
            {
                return card;
            }
        }
    }
}
