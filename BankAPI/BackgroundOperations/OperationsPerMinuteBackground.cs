using BankAPI.Data;
using BankAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BankAPI.BackGroundService
{
    public class OperationsPerMinuteBackground : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        public OperationsPerMinuteBackground(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;

        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                    foreach (var item in context.cardInfos.Include(o => o.OperationsCount).ToList())
                    {
                        var modelOperations = item.OperationsCount;
                        if(modelOperations.Count > 0)
                        {
                            modelOperations.Count--;
                            item.OperationsCount = modelOperations;
                            await context.SaveChangesAsync();
                        }
                    }
                }
                await Task.Delay(60000, stoppingToken);

            }
        }
    }
}
