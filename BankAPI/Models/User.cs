using System.Text.Json.Serialization;

namespace BankAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int CardInfoId { get; set; }
        [JsonIgnore]
        public CardInfo CardInfo { get; set; }

    }
}
