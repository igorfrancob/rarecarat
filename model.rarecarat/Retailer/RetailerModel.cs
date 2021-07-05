using core.rarecarat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace model.rarecarat
{
    public class RetailerBaseModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        //public virtual List<DiamondDetailsModel> Diamonds { get; set; }
    }

    public class RetailerDetailsModel : RetailerBaseModel, IDetailsModel
    {
    }

    public class RetailerUpdateModel : RetailerBaseModel, IUpdateModel
    {
    }

    public class RetailerCreateModel : RetailerBaseModel, ICreateModel
    {

    }

    public class RetailerListItemModel : IListItemModel
    {
    }
}
