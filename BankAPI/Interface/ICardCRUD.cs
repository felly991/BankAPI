using BankAPI.DTOs;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Interface
{
    public interface ICardCRUD
    {
        public Task<ActionResult<CardInfo>> CreateCard(CardInfoDTO cardInfoDTO);
        public Task<ActionResult<CardInfo>> DeleteCard(int id);
    }
}
