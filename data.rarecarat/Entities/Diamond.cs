using core.rarecarat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace data.rarecarat.Entities
{
    public class Diamond : IEntity
    {
        public int Id { get; set; }
        [Required]
        public ShapeType Shape { get; set; }
        [Required]
        public CertificationType Certification { get; set; }
        [Required]
        public ClarityType Clarity { get; set; }
        [Required]
        public ColorType Color { get; set; }
        [Required]
        public CutType Cut { get; set; }
        [Required]
        public DiamondType Type { get; set; }
        [Required]
        public FluorescenceType Fluorescence { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Carat { get; set; }

        [Required]
        public int RetailerId { get; set; }

        [ForeignKey( "RetailerId" )]
        public virtual Retailer Retailer { get; set; }

        public virtual List<Image> Images { get; set; }
    }
}
