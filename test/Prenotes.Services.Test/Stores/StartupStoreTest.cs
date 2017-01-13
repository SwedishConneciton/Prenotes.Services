
using Xunit;
using Prenotes.Services.Stores;

namespace Prenotes.Services.Test {

    public class StartupStoreTest : IClassFixture<Neo4jFixture> {

        private Neo4jFixture fixture;

        /// <remarks>
        /// Inside the constructor of a class containing
        /// test cases common "startup" for all test cases 
        /// can be done here (i.e. like fixing constraints)
        /// </remarks>
        /// <param name="fixture"></param>
        public StartupStoreTest(Neo4jFixture fixture) {
            this.fixture = fixture;

            // TODO: Make sure constraints are here
            // Example: StartupStore.Constraints(fixture.Session)

            // TODO: Look at CaretakerStoreTest and mimic the code 
            // which detaches plus deletes nodes between test runs
            // (i.e. blow away Organization:Prenotes and any Handshakes)
        }

        [Fact]
        public void Configure() {
            StartupStore
                .Handshakes("Kommun",new string[] {"gary@gmail.com","john@gmail.com"})
                (this.fixture.Session);

        }

        // TODO: Make a new test (i.e. fact) from a method
        // Example: An empty method with just "Assert.True()" is fine
    }
}