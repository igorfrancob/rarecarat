using System.Text.Json.Serialization;

namespace domain.rarecarat.Models
{
    public class BudgetItem
    {
        public int? Id { get; set; }
        public int? BudgetId { get; set; }
        public string AlternativeDescription { get; set; }
        public string ClGUID { get; set; }
        public string CurrencyGUID { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public string QuoteDetailName { get; set; }
        public decimal SequenceNumber { get; set; }
        public string ShipToAddress1 { get; set; }
        public string ShipToAddress2 { get; set; }
        public string ShipToAddressCity { get; set; }
        public string ShipToAddressCountry { get; set; }
        public string ShipToAddressFax { get; set; }
        public string ShipToAddressName { get; set; }
        public string ShipToAddressPhone { get; set; }
        public string ShipToAddressPostalCode { get; set; }
        public string Description { get; set; }
        public string DetailComment { get; set; }
        public string DetailGUID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public string Cl { get; set; }
        public string ClCode { get; set; }
        public string P1 { get; set; }
        public string P1GUID { get; set; }
        public string P2 { get; set; }
        public string P2GUID { get; set; }
        public string P3 { get; set; }
        public string P3GUID { get; set; }
        public string P4 { get; set; }
        public string P4GUID { get; set; }
        public string P5 { get; set; }
        public string P5GUID { get; set; }
        public string Material { get; set; }
        public string MaterialName { get; set; }
        public string ProductLine { get; set; }
        public string ProductLineName { get; set; }
        public string SalesRegion { get; set; }
        public string SalesRegionName { get; set; }
        public string Pep { get; set; }
        public string ActivitySector { get; set; }
        public string ActivitySectorName { get; set; }
        public string Project { get; set; }
        public string ProductType { get; set; }
        public int? ProductTypeCode { get; set; }
        public string AggregatorGUID { get; set; }
        public string Uncertainty { get; set; }
        public string QuantificationLimit { get; set; }
        public int? SupplierTerm { get; set; }
        public decimal? StandardCost { get; set; }
        public string Unit { get; set; }
        public int? DeliveryTermDays { get; set; }
        public string ProductNameEN { get; set; }
        public string SupplierName { get; set; }
        public string SupplierGUID { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierProductCode { get; set; }
        public string ParentSoDetailGUID { get; set; }
        public bool IsBundle { get; set; }
        public string ProductDescription { get; set; }
    }
}
