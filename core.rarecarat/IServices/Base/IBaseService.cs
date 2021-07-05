using model.rarecarat;
using System.Threading.Tasks;

namespace core.rarecarat
{
    public interface IBaseServiceAsync<TCreate, TUpdate, TDetails>
        where TCreate : ICreateModel
        where TUpdate : IUpdateModel
        where TDetails : IDetailsModel
    {
        Task<ValidationResult<object>> CreateAsync(TCreate model);

        Task<ValidationResult> UpdateAsync(TUpdate model);

        Task<OperationResult> DeleteAsync(object id);

        Task<OperationResult<TDetails>> GetDetailsModelAsync(object id);

        Task<OperationResult<TUpdate>> GetUpdateModelAsync(object id);
    }

    public interface IBaseServiceAsync<TCreate, TUpdate, TDetails, TListItem>
        where TCreate : ICreateModel
        where TUpdate : IUpdateModel
        where TDetails : IDetailsModel
        where TListItem : IListItemModel
    {
        Task<ValidationResult<object>> CreateAsync(TCreate model);

        Task<ValidationResult> UpdateAsync(TUpdate model);

        Task<OperationResult> DeleteAsync(object id);

        Task<OperationResult<TDetails>> GetDetailsModelAsync(object id);

        Task<OperationResult<TUpdate>> GetUpdateModelAsync(object id);
    }
}