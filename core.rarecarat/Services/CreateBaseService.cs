using ARGIL.Core.IModels;
using ARGIL.Core.IRepository;
using ARGIL.Core.Models;

namespace ARGIL.Core.Services
{
    public abstract class CreateBaseService<TEntity, TCreate> : BaseService<TEntity, TCreate, NotSupportedOperation, NotSupportedOperation, NotSupportedOperation>
        where TCreate : ICreateModel
        where TEntity : IEntity
    {
        protected CreateBaseService( IUnitOfWork unitOfWork, ILogger logger ) : base( unitOfWork, logger )
        {
        }
    }
}