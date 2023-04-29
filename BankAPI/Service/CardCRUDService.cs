using BankAPI.Data;
using BankAPI.DTOs;
using BankAPI.Interface;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace BankAPI.Service
{
    public class CardCRUDService : ICardCRUD
    {
        private readonly DataContext _context;

        public CardCRUDService(DataContext context)   
        {
            _context = context;
        }

        public async Task<ActionResult<CardInfo>> CreateCard(CardInfoDTO cardInfoDTO)
        {
            var card = new CardInfo
            {
                CardNumber = cardInfoDTO.CardNumber,
                CardCode = cardInfoDTO.CardCode,
            };
            var user = new User
            {
                FirstName = cardInfoDTO.User.FirstName,
                LastName = cardInfoDTO.User.LastName,
                CardInfo = card
            };
            var code = new PinCode
            {
                Code = cardInfoDTO.PinCode.Code,
                CardInfo = card
            };
            var balance = new Balance
            {
                balance = cardInfoDTO.Balance.Balance,
                CardInfo = card
            };
            var operation = new OperationsCount
            {
                Count = 0
            };
            card.User = user;
            card.PinCode = code;
            card.Balance = balance;
            card.OperationsCount = operation;
            _context.cardInfos.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<ActionResult<CardInfo>> DeleteCard(int id)
        {
            var card = _context.cardInfos.FirstOrDefault(x => x.Id == id);
            if (card == null)
            {
                return null;
            }
            else
            {
                _context.cardInfos.Remove(card);
                await _context.SaveChangesAsync();
                return card;
            }
        }
    }
}
