using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using MT5AccountOverviewDashboardTask.Models;
using MT5AccountOverviewDashboardTask.Services;
using MT5AccountOverviewDashboardTask.Tests.Helpers;
using Xunit;

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

        [Fact]
        public async Task GetAccountDetailsAsync_ReturnsEmptyAccountModel_WhenAccountNotFound()
        {
            
            var envMock = new Mock<IWebHostEnvironment>();
            envMock.Setup(e => e.ContentRootPath).Returns(Directory.GetCurrentDirectory());
            var loggerMock = new Mock<ILogger<JSONAccountService>>();
            var service = new JSONAccountService(envMock.Object, loggerMock.Object);

            var testAccountId = "nonexistent";
            var testAccounts = new List<AccountModel>
            {
                new AccountModel { accountId = "12345", balance = 10000.00, equity = 9500.00, marginLevel = 120.5, lastLogin = DateTime.Now, status = "Active" }
            };
            var dataDir = Path.Combine(envMock.Object.ContentRootPath, "Data");
            Directory.CreateDirectory(dataDir);
            var filePath = Path.Combine(dataDir, "account.json");
            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(testAccounts));

            
            var result = await service.GetAccountDetailsAsync(testAccountId);

            
            Assert.NotNull(result);
            Assert.Null(result.accountId);
            Assert.Equal(0, result.balance);
            Assert.Equal(0, result.equity);
            Assert.Equal(0, result.marginLevel);
            Assert.Equal(default(DateTime), result.lastLogin);
            Assert.Null(result.status);
        }

    }
}