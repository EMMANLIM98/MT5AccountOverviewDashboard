using MT5AccountOverviewDashboardTask.Models;

namespace MT5AccountOverviewDashboardTask.Services
{
    public interface IAccountService
    {
        Task<AccountModel> GetAccountDetailsAsync(string accountId);
        Task<List<TradeModel>> GetOpenTradesAsync(string accountId);
    }
}
