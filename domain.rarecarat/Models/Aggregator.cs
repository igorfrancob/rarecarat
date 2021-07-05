namespace domain.rarecarat.Models
{
    public class Aggregator
    {
		public string Name { get; set; }
		public string GUID { get; set; }
		public int? FrequencyCode { get; set; }
		public string Frequency { get; set; }
		public string P1 { get; set; }
		public string P1GUID { get; set; }
		public string Responsibility { get; set; }
		public string Type { get; set; }
		public int TypeCode { get; set; }
		public string PlaceName { get; set; }
		public string PlaceGUID { get; set; }
		public string PlaceAccountGUID { get; set; }
		public decimal? PlaceKms { get; set; }
		public decimal? PlaceHours { get; set; }
		public decimal? HoursPrice { get; set; }
		public decimal? KmsPrice { get; set; }
		public string PlaceLatitude { get; set; }
		public string PlaceLongitude { get; set; }
		public string ExpirationDate { get; set; }
		public string RelatedAggregatorGUID { get; set; }
		public int MaxDeadline { get; set; }
	}
}
