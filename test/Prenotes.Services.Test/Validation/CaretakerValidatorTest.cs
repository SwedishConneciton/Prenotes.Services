
using System;
using Prenotes.Services.Actions;
using Prenotes.Services.Things;
using Prenotes.Services.Validation;
using Xunit;

namespace Prenotes.Services.Test.Validation
{

    public class CaretakerValidatorTest {

        /// <summary>
        /// Fake CaretakerService built in the constructor
        /// </summary>
        private ICaretakerService service;
        
        public CaretakerValidatorTest() {
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


        [Fact]  // TODO: Copy Start
        public void TooShortCodeWhenConfirming() {
            var exception = Record.Exception(
                () => {
                    service.Confirm("gary@gmail.com", "ABC");
                }
            );

            Assert.NotNull(exception);
        }  // TODO: Copy End


        // TODO: Create a new method (say "BadCreatedWhenConfirming")
        //       that makes sure that a negative "created" property
        //       with a Caretaker object is going to thrown an exception.
        //       Copy the "TooShortCodeWhenConfirming" method and change 
        //       the name on the copied method.  Remember the whole point 
        //       of "TooShortCodeWhenConfirming" is to catch an exception.
        //       That is why we wrap our service call in "Record.Exception"
        //       then send the results into the variable "exception" which 
        //       we make sure is not null with an assertion.
    }
            

    public class FakeCaretakerService : ICaretakerService
    {
        Caretaker ICaretakerService.Confirm(string email, string code)
        {
            return new Caretaker(email, 0, "", null);
        }

        void ICaretakerService.Nuke(string email)
        {
            throw new NotImplementedException();
        }

        Caretaker ICaretakerService.Edit(Caretaker obj)
        {
            // BONUS TODO:  Make sure this method doesn't throw an error rather
            //              returns the "obj" that was passed (Hint: "return obj;" 
            //              just like with the "Confirm" method)
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Notify(string email, string message, Child[] children)
        {
            // TODO: return a Notification object rather than throwing an exception
            //       (Hint: "return new Notification(message, 0, null);")
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Reply(string email, string message, string whoami)
        {
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Retract(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        Notification[] ICaretakerService.Stream(string email, int skip, int take)
        {
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Read(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        Child[] ICaretakerService.Children(string email)
        {
            throw new NotImplementedException();
        }
    }
}