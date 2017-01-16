using System;
using Neo4j.Driver.V1;

namespace Prenotes.Services.Test {
    /// <remarks>
    /// IDisposable forces the implementation of the 
    /// Dispose method to clean up any active resources.  When
    /// this fixture is used by a test class a connection to 
    /// Neo4j is established (i.e. this.Driver) plus a session 
    /// (i.e. this.Session).  Both of these have to be cleaned 
    /// up when the fixture is discarded (i.e. not used anymore). 
    ///
    /// https://msdn.microsoft.com/en-us/library/3bwa4xa9(v=vs.110).aspx
    /// </remarks>

    public class Neo4jFixture : IDisposable
    {
        public Neo4jFixture()
        {
            this.Driver = GraphDatabase.Driver(
                "bolt://localhost:7687", 
                AuthTokens.Basic("neo4j", "prenotes")
            );
            this.Session = this.Driver.Session();
        }

        public void Dispose()
        {
            this.Driver.Dispose();
            this.Session.Dispose();
        }

        private IDriver Driver;

        /// <remark>
        /// Here we have a property "showing" the get/set 
        /// methods that exist for every property.  We mark 
        /// the set method as private so nobody can reset 
        /// the Session to something else.  Meanwhile the get  
        /// method is public and free to access by anybody.
        ///
        /// https://msdn.microsoft.com/en-us/library/w86s7x04.aspx
        /// </remark>
        /// <returns>ISession</returns>
        public ISession Session { 
            get; 
            private set; 
        }
    }
}