
using data.rarecarat.Entities;
using model.rarecarat;

namespace domain.rarecarat.AutoMapper
{
    public class DiamondProfile : BaseProfile
    {
        public DiamondProfile()
        {
            // Create
            CreateMap<DiamondCreateModel, Diamond>();

            // Details

            // Edit
            CreateMap<DiamondUpdateModel, Diamond>();
            CreateMap<Diamond, DiamondUpdateModel>();

            // Others
            CreateMap<Diamond, DiamondDetailsModel>();
            CreateMap<Diamond, DiamondListItemModel>();
        }
    }
}
