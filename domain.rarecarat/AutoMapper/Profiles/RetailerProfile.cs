
using data.rarecarat.Entities;
using model.rarecarat;

namespace domain.rarecarat.AutoMapper
{
    public class RetailerProfile : BaseProfile
    {
        public RetailerProfile()
        {
            // Create
            CreateMap<RetailerCreateModel, Retailer>();
            CreateMap<RetailerDetailsModel, Retailer>();
            // Details

            // Edit
            CreateMap<RetailerUpdateModel, Retailer>();
            CreateMap<Retailer, RetailerUpdateModel>();

            // Others
            CreateMap<Retailer, RetailerDetailsModel>();
            CreateMap<Retailer, RetailerListItemModel>();
        }
    }
}
