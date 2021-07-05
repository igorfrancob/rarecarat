namespace domain.rarecarat.Models
{
    public class ProductLine
    {
        public long Id { get; set; }

        public string Identifier { get; set; }

        public string Name { get; set; }

        public long ServiceId { get; set; }
        
        public virtual Service Service { get; set; }
    }
}
