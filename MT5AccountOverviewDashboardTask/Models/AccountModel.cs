namespace MT5AccountOverviewDashboardTask.Models
{
    public class AccountModel
    {
        public string accountId { get; set; }
        public double balance { get; set; }
        public double equity { get; set; }
        public double marginLevel { get; set; }
        public DateTime lastLogin { get; set; }
        public string status { get; set; }
    }
}
