using System.Linq;
using FluentValidation;
using Prenotes.Services.Actions;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation
{
        public class EmployeeValidator : EmployeeDecorator { 
       

        private AbstractValidator<Employee> EmployeeRules =new EmployeeRules();
       
        private AbstractValidator<string> CodeRules = new CodeRules();

        private AbstractValidator<string> MessageRules =new MessageRules();

        private AbstractValidator<Child> ChildRules =new ChildRules();
        
       
         public EmployeeValidator(IEmployeeService srv) : base(srv) {
        }
        
        public override Employee Confirm(string email, string code) {           
            CodeRules
                .Validate(code)
                .MaybeExplode();

            return base.Confirm(email, code);    
        }
        public override Employee Edit(Employee obj) {
            EmployeeRules
                .Validate(obj)
                .MaybeExplode();

            return base.Edit(obj);
        }
      public override Notification Notify(string email, string message, Child[] children) {
            MessageRules
                .Validate(message)
                .MaybeExplode();

            children?
                .ToList()
                .ForEach(
                    c => ChildRules
                            .Validate(c)
                            .MaybeExplode()

                );
           
            return base.Notify(email, message, children);
    }
 



    // TODO: Mimic what was done with CaretakerValidtor and 
    //       start with the Confirm and Edit methods

    // public class EmployeeValidator : EmployeeDecorator {
    // TODO: Add private fields (i.e. properties) for rules manager (like CodeRules, MessageRules etc.)


    // TODO: Add constructor that takes a single parameter IEmployeeSerivce passing
    //       it off to the base constructor defined by EmployeeDecorator (Hint: ": base(srv)")


    // TODO: Add Confirm method

    // TODO: Add Edit method
    //}
    }
}