namespace domain.rarecarat.Models
{
    using domain.rarecarat.Enums;
    using System;
    using System.Collections.Generic;

    public class Project : BaseModel
    {
        public long Id { get; set; }
        public string SAPIdentifier { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Observations { get; set; }
        public long? ParentId { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ProjectStatus? Status { get; set; }
        public IEnumerable<ProductLine> ProductLines { get; set; }
    }
}
