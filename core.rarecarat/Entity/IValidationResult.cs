using System.Collections.Generic;

namespace core.rarecarat
{
    public interface IValidationResult : IOperationResult
    {
        bool IsValid { get; set; }
        List<ValidationItem> ValidationErrors { get; set; }

        void AddErrorValidationItem( string message );

        void AddErrorValidationItem( string propName, string message );

        void AddErrorValidationItems( IEnumerable<ValidationItem> items );

        void MergeValidationResults( ValidationResult resultToMerge );
    }
}