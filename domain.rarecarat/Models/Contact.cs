using System.Text.Json.Serialization;

namespace domain.rarecarat.Models
{
    public class Contact
    {
        public int? Id { get; set; }
        public int? CompanyId { get; set; }
        public string CrmId { get; set; }
        public string Salutation { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
