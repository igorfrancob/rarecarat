namespace domain.rarecarat.Models
{
    using System.Text.Json.Serialization;
    public class AwardAccounts
    {
        public Account Account { get; set; }

        public Account FinancialAccount { get; set; }
    }
}
