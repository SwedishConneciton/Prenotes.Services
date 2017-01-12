using Prenotes.Services.Things;
using Xunit;

namespace Prenotes.Services.Test.Things {

    public class CaretakerTest {

        [Fact]
        public void Immutable() {
            var Dad = new Caretaker("gary@gmail.com", 0, "Gary");
            // Not possible to reassign Dad.email = "<something eles>"

            Assert.Equal("gary@gmail.com", Dad.email);
        }
    }
}