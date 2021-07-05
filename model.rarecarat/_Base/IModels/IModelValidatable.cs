
namespace model.isqnet.awards
{
    public interface IModelValidatable
    {
        void Validate( ValidationResult validationResult, string prefix = "" );
    }
}