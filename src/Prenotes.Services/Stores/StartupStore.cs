

using System;
using System.Collections.Generic;
using Neo4j.Driver.V1;
using Prenotes.Services.Exceptions;
using Prenotes.Services.Logging;

namespace Prenotes.Services.Stores {

    /// <summary>
    /// 
    /// </summary>
    public static class StartupStore {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Func<ISession, int> Constraints() {
            return (ISession session) => {

                try {
                    var results = session
                        .Run(
                            "CREATE CONSTRAINT ON (o:Organization) ASSERT o.name IS UNIQUE " + 
                            "CREATE CONSTRAINT ON (u:User) ASSERT u.epost IS UNIQUE " + 
                            "CREATE CONSTRAINT ON (d:Daycare) ASSERT d.name IS UNIQUE "
                        )
                        .Consume();

                    Log.StartupConstraints(results.Counters.ConstraintsAdded);
                    return results.Counters.ConstraintsAdded;
                } catch (ClientException e) {
                    throw new SystemException(e.Message);
                }
            };
        }

        public static Func<ISession, int> Indexes() {
            return (ISession session) => {
                return 0;
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="emails"></param>
        /// <returns></returns>
        public static Action<ISession> Handshakes(string name, string[] emails) {
            return (ISession session) => {
                long created = new System.DateTimeOffset().ToUnixTimeSeconds();

                try {
                    var results = session
                        .Run(
                            "MERGE (o:Organization:Prenotes {name: {name}}) " +
                            "ON CREATE SET o.created = {created} " +
                            "WITH o " + 
                            "UNWIND {emails} AS email " +
                            "CREATE (h:Handshake:Super {code: {code}, epost: email, created: {created}}) " + 
                            "-[:FOR]->(o)",
                            new Dictionary<string, object> {
                                {"name", name},
                                {"created", created},
                                {"emails", emails},
                                {"code", Utils.NextCode()}
                            }
                        )
                        .Consume();    
                } catch (ClientException e) {
                    throw new SystemException(e.Message);
                }
            };
        }
    }
}