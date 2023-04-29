using System.Text.Json.Serialization;

namespace BankAPI.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public decimal balance { get; set; }
        public int cardInfoID { get; set; }
        [JsonIgnore]
        public CardInfo CardInfo { get; set; }
    }
}
