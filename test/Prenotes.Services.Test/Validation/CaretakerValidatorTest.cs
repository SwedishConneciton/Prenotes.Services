
using Prenotes.Services.Actions;
using Prenotes.Services.Things;
using Prenotes.Services.Validation;
using Xunit;

namespace Prenotes.Services.Test.Validation {

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
                        0
                    );
                }
            );

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Create works
        /// </summary>
        [Fact]
        public void GoodConfirm() {
            // Todo: The Handshake (Thing) doesn't have a 
            // valid constructor that sets the readonly properties.
            // Fix that first then make sure this test case works.
            var obj = service.Confirm(
                new Caretaker("gary@gmail.com", 0, ""),
                0
            );

            Assert.NotNull(obj);
        }

        /// <summary>
        /// Positive Caretaker but validation for Handshake should fail
        /// </summary>
        [Fact]
        public void BadHandshakeWhenConfirming() {
            // Todo: This should fail rather than pass which means we need to correct
            // the code in the HandshakeRules.cs
            var exception = Record.Exception(
                () => {
                    service.Confirm(
                        new Caretaker("gary@gmail.com", 0, ""),
                        0
                    );
                }
            );

            // Todo: When Handshake validation fails then the exception won't be null
            Assert.Null(exception);
        }

        
    }


    public class FakeCaretakerService : ICaretakerService
    {
        Caretaker ICaretakerService.Confirm(Caretaker obj, int code)
        {
            return obj;
        }
    }
}