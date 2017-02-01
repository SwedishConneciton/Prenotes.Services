
using System;
using System.Linq;
using Prenotes.Services.Actions;
using Prenotes.Services.Things;
using Prenotes.Services.Validation;
using Prenotes.Services.Exceptions;
using Xunit;

namespace Prenotes.Services.Test.Validation
{

    public class EmployeeValidatorTest {

        /// <summary>
        /// Fake CaretakerService built in the constructor
        /// </summary>
        private ICaretakerService service;
        
        public EmployeeValidatorTest() {
            this.service = new CaretakerValidator(
                new FakeCaretakerService()
            );
        }

        /// <summary>
        /// When creating a Caretaker the email argument must 
        /// be a valid email.  Note, that the Handshake object 
        /// isn't valid but the Caretaker rules fail first.
        /// </summary>
        [Fact]
        public void BadEmailWhenCreating() {
            var exception = Record.Exception(
                () => {
                    service.Confirm("gary", "");
                }
            );

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Confirmation
        /// </summary>
        [Fact]
        public void GoodConfirm() {
            var obj = service.Confirm("gary@gmail.com", "ABC123");

            Assert.NotNull(obj);
        }

        /// <summary>
        /// Positive Caretaker but validation for the code should fail
        /// </summary>
        [Fact]
        public void EmptyCodeWhenConfirming() {
            var exception = Record.Exception(
                () => {
                    service.Confirm("gary@gmail.com", "");
                }
            );

            Assert.NotNull(exception);
        }


        [Fact]  
        public void TooShortCodeWhenConfirming() {
            var exception = Record.Exception(
                () => {
                    service.Confirm("gary@gmail.com", "ABC" );
                }
            );

            Assert.NotNull(exception);
        }  
      
      
        [Fact]  
        public void BadCreatedWhenConfirming() {
            var exception = Record.Exception(
                () => {
                    service.Confirm(
                        "gary@gmail.com", "ABC123"
                    );
                }
            );

         
            Assert.NotNull(exception);
        }


        [Fact]
        public void BadEmailWhenEditing() {
            var exception = Record.Exception(
                () => {
                    service.Edit(
                       new Caretaker("Gary", 0, "", null) 
                    );
                }
            );
            Assert.NotNull(exception);
        }
        
        [Fact]
        public void EmptyMessageWhenNotifying(){
            var message = "";

            var exception = Record.Exception(
                () => {
                    service.Notify("gary@gmail.com", message, null);
                }
            );

            Assert.IsType<ValidationException>(exception);
        }
        
        [Fact]
        public void TooBigMessageWhenNotifying() {
            var message = String.Join(
                "", 
                new string[200].Select(x => "a")
            );

            var exception = Record.Exception(
                () => {
                    service.Notify("gary@gmail.com", message, null);
                }
            );

            Assert.IsType<ValidationException>(exception);          
        }

        [Fact]
        public void BadKidsWhenNotifying() {
            var children = new Child[] {
                new Child("", null)
            };

            var exception = Record.Exception(
                () => {
                    service.Notify("gary@gmail.com", "Good message", children);
                }
            );

            Assert.IsType<ValidationException>(exception);
        }

        [Fact]
        public void Notifying() {
            var children = new Child[] {
                new Child("Julia", null)
            };

            var Notification = service.Notify("gary@gmail.com", "Good message", children);

            Assert.NotNull(Notification);
        }
    }


    public class FakeEmployeeService : IEmployeeService
    {
        public Child Add(string email, Child child)
        {
            throw new NotImplementedException();
        }

        public Notification Bad(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        public Child[] Children(string email)
        {
            throw new NotImplementedException();
        }

        public Employee Confirm(string email, string code)
        {
            return new Employee(email, 0, null);
        }

        public Employee Edit(Employee obj)
        {
            return new Employee(obj.email, 0, null);
        }

        public Notification Notify(string email, string message, Child[] children)
        {
            return new Notification("", message, 0, "en");
        }

        public Employee[] Others(string email)
        {
            throw new NotImplementedException();
        }

        public Notification Read(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        public Handshake Register(string caretaker, string email, Child[] children)
        {
            throw new NotImplementedException();
        }

        public void Remove(string email, Child child)
        {
            throw new NotImplementedException();
        }

        public Notification Reply(string email, string message, string whoami)
        {
            throw new NotImplementedException();
        }

        public Notification Retract(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        public Notification[] Stream(string email, int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}