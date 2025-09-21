namespace MT5AccountOverviewDashboardTask.Models
{
    public class TradeModel
    {
        public string ticket { get; set; } = string.Empty;
        public string symbol { get; set; } = string.Empty;
        public double volume { get; set; }
        public decimal profit { get; set; }
    }
}
