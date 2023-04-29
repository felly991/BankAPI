using System.Text.Json.Serialization;

namespace BankAPI.Models
{
    public class PinCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CardInfoId { get; set; }
        [JsonIgnore]
        public CardInfo CardInfo { get; set; }
    }
}
