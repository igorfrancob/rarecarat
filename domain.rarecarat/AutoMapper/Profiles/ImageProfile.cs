

using data.rarecarat.Entities;
using model.rarecarat;

namespace domain.rarecarat.AutoMapper
{
    public class ImageProfile : BaseProfile
    {
        public ImageProfile()
        {
            // Create
            CreateMap<ImageCreateModel, Image>();
            CreateMap<ImageListItemModel, Image>();
            // Details

            // Edit
            CreateMap<ImageUpdateModel, Image>();
            CreateMap<Image, ImageUpdateModel>();

            // Others
            CreateMap<Image, ImageDetailsModel>();
            CreateMap<Image, ImageListItemModel>();
        }
    }
}
