namespace BankAPI.Models
{
    public class CardInfo
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardCode { get; set; }
        public User User { get; set; }
        public PinCode PinCode { get; set; }
        public Balance Balance { get; set; }
        public OperationsCount OperationsCount { get; set; }
    }
}
