
using Prenotes.Services.Stores;
using Prenotes.Services.Things;
using Xunit;

namespace Prenotes.Services.Test.Stores {

    public class CaretakerStoreTest : IClassFixture<Neo4jFixture> {

        private Neo4jFixture fixture;

        public CaretakerStoreTest(Neo4jFixture fixture) {
            this.fixture = fixture;

            using (var tx = this.fixture.Session.BeginTransaction())
            {
                tx.Run("MATCH (n:Caretaker) DETACH DELETE n");
                tx.Success();
            }
        }

        [Fact]
        public void Connection() {
            string email = "gary@gmail.com";

            var obj = CaretakerStore
                .Create(
                    new Caretaker(email)
                )
                (this.fixture.Session);

            Assert.Equal(email, obj.email);
        }
    }
}