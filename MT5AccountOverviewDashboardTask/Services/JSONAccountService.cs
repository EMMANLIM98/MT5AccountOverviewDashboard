using Microsoft.Extensions.Logging;
using MT5AccountOverviewDashboardTask.Models;
using System.Text.Json;

namespace MT5AccountOverviewDashboardTask.Services
{
    public class JSONAccountService : IAccountService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<JSONAccountService> _logger;

        public JSONAccountService(IWebHostEnvironment env, ILogger<JSONAccountService> logger)
        {
            _env = env;
            _logger = logger;
        }

        public async Task<AccountModel> GetAccountDetailsAsync(string accountId)
        {
            try
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data", "account.json");
                var json = await File.ReadAllTextAsync(filePath);
                var accounts = JsonSerializer.Deserialize<List<AccountModel>>(json);
                var account = accounts?.FirstOrDefault(a => a.accountId == accountId);
                if (account == null)
                {
                    _logger.LogWarning("Account with ID {AccountId} not found.", accountId);
                }
                return account ?? new AccountModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading account details for account {AccountId}", accountId);
                return new AccountModel();
            }
        }

        public async Task<List<TradeModel>> GetOpenTradesAsync(string accountId)
        {
            try
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data", "trades.json");
                var json = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<List<TradeModel>>(json) ?? new List<TradeModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading open trades for account {AccountId}", accountId);
                return new List<TradeModel>();
            }
        }
    }
}
