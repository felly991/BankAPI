using System.Text.Json.Serialization;

namespace BankAPI.Models
{
    public class OperationsCount
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int CardInfoId { get; set; }
        [JsonIgnore]
        public CardInfo CardInfo { get; set; }
    }
}
