
using System.Linq;
using Neo4j.Driver.V1;
using Xunit;

namespace Prenotes.Services.Test.Stores {

    public class CaretakerStoreTest {

        [Fact]
        public void Connection() {
            using (var driver = GraphDatabase.Driver(
                "bolt://localhost:7687", 
                AuthTokens.Basic("neo4j", "prenotes"))
            )
            using (var session = driver.Session())
            {
                var result = session.Run("MATCH (a:Caretaker) return a");

                Assert.Equal(0, result.ToList().Count());
            }
        }
    }
}