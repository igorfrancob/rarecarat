namespace domain.rarecarat.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Awards
    {
        public AwardAccounts Accounts { get; set; }
        public Contact Contact { get; set; }
        public string Name { get; set; } // - 
        public string Owner { get; set; } // email
        public string OwnerEmail { get; set; } // email
        public string Type { get; set; } // cliente/retalho
        public decimal TypeCode { get; set; }
        public string BusinessLine { get; set; }
        public decimal? BusinessLineCode { get; set; }
        public string Cl { get; set; }
        public string ClCode { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyCode { get; set; }
        public string CustomerRef { get; set; }
        public string Department { get; set; }
        public string DepartmentCode { get; set; }
        public string Source { get; set; }
        public decimal? SourceCode { get; set; }
        public string Description { get; set; }
        public string BillAddress1 { get; set; }
        public string BillAddress2 { get; set; }
        public string BillAddressCountry { get; set; }
        public string BillAddressCity { get; set; }
        public string BillAddressPostalCode { get; set; }
        public string ShipAddress1 { get; set; }
        public string ShipAddress2 { get; set; }
        public string ShipAddressCity { get; set; }
        public string ShipAddressCountry { get; set; }
        public string ShipAddressPostalCode { get; set; }
        public string Date { get; set; }
        public string EffectiveFrom { get; set; }
        public string EffectiveTo { get; set; }
        public string ExpirationDate { get; set; }
        public string ReceptionDate { get; set; }
        public string AcceptanceDate { get; set; }
        public string ExecutionLocationType { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentMethodCode { get; set; }
        public string PaymentTerms { get; set; }
        public string PaymentTermsCode { get; set; }
        public string QuoteId { get; set; }
        public decimal Revision { get; set; }
        public string SapSONumber { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalTransportAmount { get; set; }
        public string ActivitySector { get; set; }
        public string ActivitySectorName { get; set; }
        public string DistributionChannel { get; set; }
        public string DistributionChannelName { get; set; }
        public string OwnerNumber { get; set; }
        public string OwnerClName { get; set; }
        public string OwnerCl { get; set; }
        public string ManagerName { get; set; }
        public string ManagerNameNumber { get; set; }
        public string ManagerClName { get; set; }
        public string ManagerCl { get; set; }
        public string SalesOffice { get; set; }
        public string SalesOfficeName { get; set; }
        public bool CustomerType { get; set; }
        public string TaxType { get; set; }
        public decimal? TaxTypeCode { get; set; }
        public string ExternalID { get; set; }
        public string CrmId { get; set; }
        public string ProposalId { get; set; }
        public string OrderCode { get; set; }
        public List<Aggregator> Aggregators { get; set; }
        public List<BudgetItem> Items { get; set; }
        public List<BudgetComment> Comments { get; set; }
        public List<Pep> Peps { get; set; }
        public string PurchaseOrderNumber { get; set; }
    }
}
