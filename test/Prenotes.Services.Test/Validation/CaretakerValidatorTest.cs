
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
                new FakeCaretakerService(),  // class is defined at the bottom of this file
                new CaretakerRules(),
                new HandshakeRules()
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
                    service.Create(
                        new Caretaker("gary", 0, ""),
                        new Handshake()
                    );
                }
            );

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Create works
        /// </summary>
        [Fact]
        public void GoodCreate() {
            // Todo: The Handshake (Thing) doesn't have a 
            // valid constructor that sets the readonly properties.
            // Fix that first then make sure this test case works.
            var obj = service.Create(
                new Caretaker("gary@gmail.com", 0, ""),
                new Handshake()
            );

            Assert.NotNull(obj);
        }

        /// <summary>
        /// Positive Caretaker but validation for Handshake should fail
        /// </summary>
        [Fact]
        public void BadHandshakeWhenCreating() {
            // Todo: This should fail rather than pass which means we need to correct
            // the code in the HandshakeRules.cs
            var exception = Record.Exception(
                () => {
                    service.Create(
                        new Caretaker("gary@gmail.com", 0, ""),
                        new Handshake()
                    );
                }
            );

            // Todo: When Handshake validation fails then the exception won't be null
            Assert.Null(exception);
        }

        
    }


    public class FakeCaretakerService : ICaretakerService
    {
        Caretaker ICaretakerService.Create(Caretaker obj, Handshake shake)
        {
            return obj;
        }
    }
}