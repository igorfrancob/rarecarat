namespace domain.rarecarat.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class FinancialAccount
    {
        [JsonPropertyName("Address1")]
        public string AccountAddress1 { get; set; }
        [JsonPropertyName("Address2")]
        public string AccountAddress2 { get; set; }
        [JsonPropertyName("AddressCity")]
        public string AccountAddressCity { get; set; }
        [JsonPropertyName("AddressLatitude")]
        public string AccountAddressLatitude { get; set; }
        [JsonPropertyName("AddressLongitude")]
        public string AccountAddressLongitude { get; set; }
        [JsonPropertyName("AddressPostalCode")]
        public string AccountAddressPostalCode { get; set; }
        [JsonPropertyName("CAE")]
        public string AccountCAE { get; set; }
        [JsonPropertyName("CAECode")]
        public string AccountCAECode { get; set; }
        [JsonPropertyName("Country")]
        public string AccountCountry { get; set; }
        [JsonPropertyName("CountryCode")]
        public string AccountCountryCode { get; set; }
        [JsonPropertyName("Email")]
        public string AccountEmail { get; set; }
        [JsonPropertyName("Fax")]
        public string AccountFax { get; set; }
        [JsonPropertyName("GUID")]
        public string AccountGUID { get; set; }
        [JsonPropertyName("NIF")]
        public string AccountNIF { get; set; }
        [JsonPropertyName("Name")]
        public string AccountName { get; set; }
        [JsonPropertyName("Name2")]
        public string AccountName2 { get; set; }
        [JsonPropertyName("Number")]
        public string AccountNumber { get; set; }
        [JsonPropertyName("NumberOfEmployees")]
        public string AccountNumberOfEmployees { get; set; }
        [JsonPropertyName("NumberOfEmployeesCode")]
        public object AccountNumberOfEmployeesCode { get; set; }
        [JsonPropertyName("PaymentTerms")]
        public string AccountPaymentTerms { get; set; }
        [JsonPropertyName("PaymentTermsCode")]
        public string AccountPaymentTermsCode { get; set; }
        [JsonPropertyName("Phone")]
        public string AccountPhone { get; set; }
        [JsonPropertyName("SalesRegion")]
        public string AccountSalesRegion { get; set; }
        [JsonPropertyName("SalesRegionCode")]
        public string AccountSalesRegionCode { get; set; }
        [JsonPropertyName("SecondPhone")]
        public string AccountSecondPhone { get; set; }
        [JsonPropertyName("Type")]
        public string AccountType { get; set; }
        [JsonPropertyName("TypeCode")]
        public int AccountTypeCode { get; set; }
        [JsonPropertyName("WebSite")]
        public string AccountWebSite { get; set; }
        [JsonPropertyName("ParentAccount")]
        public string ParentAccount { get; set; }
        [JsonPropertyName("ParentAccountGUID")]
        public string ParentAccountGUID { get; set; }
    }
}
