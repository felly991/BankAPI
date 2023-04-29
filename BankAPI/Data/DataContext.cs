using BankAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CardInfo> cardInfos { get; set; }
        public DbSet<PinCode> pinCodes { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Balance> balances { get; set; }
        public DbSet<OperationsCount> operations { get; set; }
    }
}
