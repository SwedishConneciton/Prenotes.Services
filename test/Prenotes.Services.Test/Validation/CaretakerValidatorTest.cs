
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
                    service.Confirm(
                        new Caretaker("gary", 0, ""),
                        ""
                    );
                }
            );

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Confirmation
        /// </summary>
        [Fact]
        public void GoodConfirm() {
            var obj = service.Confirm(
                new Caretaker("gary@gmail.com", 0, ""),
                "ABC123"
            );

            Assert.NotNull(obj);
        }

        /// <summary>
        /// Positive Caretaker but validation for the code should fail
        /// </summary>
        [Fact]
        public void EmptyCodeWhenConfirming() {
            var exception = Record.Exception(
                () => {
                    service.Confirm(
                        new Caretaker("gary@gmail.com", 0, ""),
                        ""
                    );
                }
            );

            Assert.NotNull(exception);
        }


        [Fact]  // TODO: Copy Start
        public void TooShortCodeWhenConfirming() {
            var exception = Record.Exception(
                () => {
                    service.Confirm(
                        new Caretaker("gary@gmail.com", 0, ""),  // TODO: Make sure "created" isn't positive or 0
                        "ABC"  // TODO: Make sure the code isn't wrong!  Change to "ABC123" for example
                    );
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
        Caretaker ICaretakerService.Confirm(Caretaker obj, string code)
        {
            return obj;
        }

        void ICaretakerService.Delete(Caretaker obj)
        {
            throw new NotImplementedException();
        }

        void ICaretakerService.Detach(Caretaker obj, Child child)
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

        Notification ICaretakerService.Notify(Notification obj, Child[] children)
        {
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Retrack(Notification obj)
        {
            throw new NotImplementedException();
        }
    }
}