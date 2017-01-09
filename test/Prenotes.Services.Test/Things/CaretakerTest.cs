using Prenotes.Services.Things;
using Xunit;

namespace Prenotes.Services.Test.Things {

    public class CaretakerTest {

        /// <summary>
        /// Every struct should be immutable.  This isn't the 
        /// default behavior.  Instead, with Caretaker the 
        /// email property is marked as readonly.
        /// </summary>
        [Fact]
        public void Immutable() {
            var Dad = new Caretaker("gary@gmail.com");
            // Not possible to reassign Dad.email = "<something eles>"

            Assert.Equal("gary@gmail.com", Dad.email);
        }
    }
}