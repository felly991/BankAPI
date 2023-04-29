using BankAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.DTOs
{
    public class CardInfoDTO
    {
        public string CardNumber { get; set; }
        public string CardCode { get; set; }
        public PinCodeDTO PinCode { get; set; }
        public UserDTO User { get; set; }
        public BalanceDTO Balance { get; set; }
        public OperationsDTO Operations { get; set; }
    }
}
