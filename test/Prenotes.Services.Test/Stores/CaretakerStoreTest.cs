
using Prenotes.Services.Stores;
using Prenotes.Services.Things;
using Xunit;

namespace Prenotes.Services.Test.Stores {

    /// <remarks>
    /// IClassFixture has what is called a generic signature (i.e. where the 
    /// Neo4jFixture is between <>).  The interface wants us to tell 
    /// it which class we are passing as our fixture.
    ///
    /// https://msdn.microsoft.com/en-us/library/512aeb7t.aspx
    /// </remarks>
    public class CaretakerStoreTest : IClassFixture<Neo4jFixture> {

        private Neo4jFixture fixture;

        public CaretakerStoreTest(Neo4jFixture fixture) {
            this.fixture = fixture;

            /// <remarks>
            /// The "using" keyword works like IDisposable in that 
            /// the variable "tx" will get it's Dispose method called 
            /// automatically after the "using" block is done.
            /// </remarks>
            using (var tx = this.fixture.Session.BeginTransaction())
            {
                tx.Run("CREATE CONSTRAINT ON (u:User) ASSERT u.email IS UNIQUE");
                tx.Success();
            }

            using (var tx = this.fixture.Session.BeginTransaction()) {
                tx.Run("MATCH (n:Caretaker) DETACH DELETE n");
                tx.Run("MERGE (e:User:Employee {email: 'stella@kommun.se'})");
                tx.Success();
            }
        }

        [Fact]
        public void Create() {
            var obj = CaretakerStore
                .Create(
                    new Caretaker("gary@gmail.com", 0, "Gary"),
                    new Handshake()
                )
                (this.fixture.Session);

            Assert.NotEqual(0, obj.created);
        }
    }
}