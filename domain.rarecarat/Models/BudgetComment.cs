using System.Text.Json.Serialization;

namespace domain.rarecarat.Models
{
    public class BudgetComment
    {
        public int? Id { get; set; }
        public int? BudgetId { get; set; }
        public string Symbol { get; set; }
        public string Text { get; set; }
    }
}
