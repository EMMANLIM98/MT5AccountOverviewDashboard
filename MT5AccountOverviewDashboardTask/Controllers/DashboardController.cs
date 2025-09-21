using Microsoft.AspNetCore.Mvc;
using MT5AccountOverviewDashboardTask.Services;

namespace MT5AccountOverviewDashboardTask.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IAccountService _accountService;

        public DashboardController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            string accountId = "12345";
            var account = await _accountService.GetAccountDetailsAsync(accountId);
            var trades = await _accountService.GetOpenTradesAsync(accountId);

            if (account == null)
            {
                ViewBag.Error = "Unable to load the account details.";
                return View();
            }

            var model = new
            {
                Account = account,
                Trades = trades,
                OpenTradesCount = trades.Count
            };

            return View(model);
        }
    }
}
