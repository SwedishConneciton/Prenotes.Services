
using FluentValidation;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {

    public class ChildRules : AbstractValidator<Child> {
        
        public ChildRules() {
            // TODO: Add rule to check that the "name" property
            //       is not empty.  Look at the CaretakerRules.cs
            //       as an example.  Tips: the "RuleFor" method
            //       will need a selector like "x => x.name" and 
            //       the "NotEmpty" method from Fluet ought to be
            //       chained.  That's it.
        }
    }
}