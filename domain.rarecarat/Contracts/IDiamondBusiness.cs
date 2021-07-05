using core.rarecarat;
using data.rarecarat.Entities;
using model.rarecarat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.rarecarat.Contracts
{
    public interface IDiamondBusiness : IBaseServiceAsync<DiamondCreateModel, DiamondUpdateModel, DiamondDetailsModel, DiamondListItemModel>
    {
        Task<OperationResult<List<DiamondListItemModel>>> GetAllAsync();
    }



}
