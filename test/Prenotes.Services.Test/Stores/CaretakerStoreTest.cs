
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Prenotes.Services.Logging;
using Prenotes.Services.Stores;
using Prenotes.Services.Test.Logging;
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

        private string[] Codes = new string[] { "YAI123" };

        private string[] Caretakers = new string[] { "gary@gmail.com" };

        protected static TestLoggerSink TestLoggerSink { get; } = new TestLoggerSink();
        

        public CaretakerStoreTest(Neo4jFixture fixture) {
            this.fixture = fixture;

            using (var tx = this.fixture.Session.BeginTransaction())
            {
                tx.Run("CREATE CONSTRAINT ON (u:User) ASSERT u.email IS UNIQUE");
                tx.Success();
            }

            using (var tx = this.fixture.Session.BeginTransaction()) {
                tx.Run(
                    "MATCH (h:Handshake) WHERE h.code IN [{codes}] OPTIONAL MATCH (h)--(x) DETACH DELETE h, x",
                    new Dictionary<string, object> { {"codes", Codes} }
                );
                tx.Run(
                    "MATCH (c:Caretaker) WHERE c.email IN [{emails}] OPTIONAL MATCH (c)--(x) DETACH DELETE c, x",
                    new Dictionary<string, object> { {"emails", Caretakers} }
                );
                tx.Run(
                    "CREATE (h:Handshake {email: {email}, code: {code}})-[:WITH]->(:Child {name: 'Julia', created: 1}), (h)-[:WITH]->(:Child {name: 'Berry', created: 1}), (h)<-[:CREATED]-(e:User:Employee {email: {staff}})",
                    new Dictionary<string, object> { 
                        { "email", Caretakers.First() },
                        { "code", Codes.First() },
                        { "staff", "stella@kommun.se" }
                    }
                );
                tx.Success();
            }

            PrenotesLogManager.LoggerFactory = new LoggerFactory();
            PrenotesLogManager.LoggerFactory.AddProvider(new TestLoggerProvider(TestLoggerSink));
        }

        [Fact]
        public void Confirm() {
            TestLoggerSink.Clear();
            var email = Caretakers.First();

            var obj = CaretakerStore
                .Confirm(
                    email,
                    Codes.First()
                )
                (this.fixture.Session);

            
            Assert.Equal($"Confirmed {email} having {obj.children.Count()} children", TestLoggerSink.Records.First().Format());
        }
    }
}