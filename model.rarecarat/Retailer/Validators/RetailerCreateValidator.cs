using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.rarecarat.Demo.Validators
{
    public class RetailerCreateValidator : AbstractValidator<DiamondCreateModel>
    {
        public RetailerCreateValidator()
        {
            //RuleFor( x => x.RetailerId ).NotEqual( 0 ).WithMessage( "Please specify a retailer" );
            //RuleFor( x => x.StringValue ).NotEmpty().WithMessage( "Please specify a DiamondCreateValidator" ); ;
            ////RuleFor( x => x.Forename ).NotEmpty().WithMessage( "Please specify a first name" );
            ////RuleFor( x => x.Discount ).NotEqual( 0 ).When( x => x.HasDiscount );
            ////RuleFor( x => x.Address ).Length( 20, 250 );
            //RuleFor( x => x.BooleanValue ).Must( BeABooleanValue ).WithMessage( "Please set as true" );
        }
        private bool BeABooleanValue( bool? value )
        {
            return ( value.HasValue && value.Value );
        }
    }

}
