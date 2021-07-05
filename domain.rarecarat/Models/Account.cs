namespace domain.rarecarat.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Account
    {
        public int? Id { get; set; }
        public string CrmId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string NumberOfEmployees { get; set; }
        public int? NumberOfEmployeesCode { get; set; }
        public string AccountType { get; set; }
        public int AccountTypeCode { get; set; }
        public string ParentAccount { get; set; }
        public string ParentAccountGUID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressLatitude { get; set; }
        public string AddressLongitude { get; set; }
        public string AddressPostalCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        public string SecondPhone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string WebSite { get; set; }
        public string CAE { get; set; }
        public string CAECode { get; set; }
        public string NIF { get; set; }
        public string Number { get; set; } 
        public string PaymentTerms { get; set; }
        public string PaymentTermsCode { get; set; }
        public string SalesRegion { get; set; }
        public string SalesRegionCode { get; set; }
    }
}
