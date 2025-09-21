using Xunit;
using Moq;
using MT5AccountOverviewDashboardTask.Services;
using Microsoft.Extensions.Logging;
using MT5AccountOverviewDashboardTask.Tests.Helpers;

namespace MT5AccountOverviewDashboardTask.Tests.Services
{
    public class JSONAccountServiceTests
    {
        private readonly ILogger<JSONAccountService> logger = new Mock<ILogger<JSONAccountService>>().Object;

        [Fact]
        public async Task GetAccountDetails_ReturnsAccount()
        {
            var env = new FakeWebHostEnvironment
            {
                ContentRootPath = Directory.GetCurrentDirectory()
            };
            
            var service = new JSONAccountService(env, logger);

            var account = await service.GetAccountDetailsAsync("12345");

            Assert.NotNull(account);
            Assert.Equal("12345", account.accountId);
        }

        [Fact]
        public async Task GetOpenTradesAsync_ReturnsTrades()
        {
            var env = new FakeWebHostEnvironment
            {
                ContentRootPath = Directory.GetCurrentDirectory()
            };
            var service = new JSONAccountService(env, logger);

            var trades = await service.GetOpenTradesAsync("12345");

            Assert.NotNull(trades);
            Assert.NotEmpty(trades);
            Assert.All(trades, t => Assert.False(string.IsNullOrWhiteSpace(t.ticket)));
        }
    }
}