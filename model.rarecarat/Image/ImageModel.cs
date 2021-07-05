using core.rarecarat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace model.rarecarat
{
    public class ImageBaseModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public int DiamondId { get; set; }
        public DiamondDetailsModel Diamond { get; set; }
    }

    public class ImageDetailsModel : ImageBaseModel, IDetailsModel
    {
    }

    public class ImageUpdateModel : ImageBaseModel, IUpdateModel
    {
    }

    public class ImageCreateModel : ImageBaseModel, ICreateModel
    {

    }

    public class ImageListItemModel : IListItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

    }
}
