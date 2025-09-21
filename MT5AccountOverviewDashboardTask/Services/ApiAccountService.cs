using MT5AccountOverviewDashboardTask.Models;
using System.Diagnostics;
using System.Security.Principal;

namespace MT5AccountOverviewDashboardTask.Services
{
    public class ApiAccountService: IAccountService
    {
        private readonly HttpClient _http;

        public ApiAccountService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AccountModel> GetAccountDetailsAsync(string accountId)
        {
            try
            {
                var result = await _http.GetFromJsonAsync<AccountModel>($"/api/mt5/accounts/{accountId}");
                return result ?? new AccountModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new AccountModel();
            }
        }

        public async Task<List<TradeModel>> GetOpenTradesAsync(string accountId)
        {
            try
            {   var result = await _http.GetFromJsonAsync<List<TradeModel>>($"/api/mt5/accounts/{accountId}/trades");
                return result ?? new List<TradeModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new List<TradeModel>();
            }
        }
    }
}
