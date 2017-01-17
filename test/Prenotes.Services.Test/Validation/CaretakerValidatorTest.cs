
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
            // TODO: This should fail rather than pass which means we need to correct
            // the code in the CodeRules.cs (i.e. a blank isn't correct)
            var exception = Record.Exception(
                () => {
                    service.Confirm(
                        new Caretaker("gary@gmail.com", 0, ""),
                        ""
                    );
                }
            );

            // TODO: When code validation fails then the exception won't be null
            Assert.NotNull(exception);
        }
[Fact]
        public void TooShortCodeWhenConfirming() {
            // TODO: This should fail rather than pass which means we need to correct
            // the code in the CodeRules.cs (i.e. a blank isn't correct)
            var exception = Record.Exception(
                () => {
                    service.Confirm(
                        new Caretaker("gary@gmail.com", 0, ""),
                        "ABC"
                    );
                }
            );

            // TODO: When code validation fails then the exception won't be null
            Assert.NotNull(exception);
        }

    }
            

    public class FakeCaretakerService : ICaretakerService
    {
        // TODO: Fix the other methods (e.g. Delete, Edit etc.) so that 
        // either return something or if the method is void then remove
        // the throw statement.
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