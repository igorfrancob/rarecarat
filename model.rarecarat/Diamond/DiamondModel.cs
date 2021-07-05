using core.rarecarat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace model.rarecarat
{
    public class DiamondBaseModel
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

        public virtual RetailerDetailsModel Retailer { get; set; }

        public virtual List<ImageListItemModel> Images { get; set; }
    }

    public class DiamondDetailsModel : DiamondBaseModel, IDetailsModel
    {
    }

    public class DiamondUpdateModel : DiamondBaseModel, IUpdateModel
    {
    }

    public class DiamondCreateModel : DiamondBaseModel, ICreateModel
    {
        
    }

    public class DiamondListItemModel : DiamondBaseModel, IListItemModel
    {
    }

}