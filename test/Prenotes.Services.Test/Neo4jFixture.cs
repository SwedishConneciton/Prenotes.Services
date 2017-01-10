using System;
using Neo4j.Driver.V1;

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

    public ISession Session { 
        get; 
        private set; 
    }
}