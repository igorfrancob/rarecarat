namespace domain.rarecarat.Models
{
    using System.Text.Json.Serialization;
    public class Pep
    {
        [JsonPropertyName("Lvl")]
        public int Lvl { get; set; }
        [JsonPropertyName("ActivitySector")]
        public string ActivitySector { get; set; }
        [JsonPropertyName("ProductLine")]
        public string ProductLine { get; set; }
        [JsonPropertyName("Cl")]
        public string Cl { get; set; }
    }
}
