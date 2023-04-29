using BankAPI.DTOs;
using BankAPI.Interface;
using BankAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCRUDController : ControllerBase
    {
        private readonly ICardCRUD _cardCRUD;
        public UserCRUDController(ICardCRUD cardCRUD)
        {
            _cardCRUD = cardCRUD;
        }

        [HttpPost]
        public Task<ActionResult<CardInfo>> CreateCard([FromQuery]CardInfoDTO cardInfoDTO)
        {
            return _cardCRUD.CreateCard(cardInfoDTO);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<CardInfo>> DeleteCard(int id)
        {
            var card = await _cardCRUD.DeleteCard(id);
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
